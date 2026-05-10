using Proiect_PAOO_Organizare_Evenimente.DAL;
using Proiect_PAOO_Organizare_Evenimente.Forms;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    /// <summary>
    /// Dashboard Admin: KPI cards, gestionare useri (suspendare/edit/rol),
    /// gestionare evenimente (suspendare/edit) si grafice de statistici.
    /// </summary>
    public partial class UCAdminDashboard : UserControl
    {
        private readonly UserRepository _userRepo = new();
        private readonly EvenimentRepository _evRepo = new();
        private readonly AdminStatsRepository _stats = new();

        // Cache pentru graficele paint-ate
        private List<AdminStatsRepository.StatRow> _statTip = new();
        private List<AdminStatsRepository.StatRow> _statRol = new();
        private List<AdminStatsRepository.StatRow> _statTop = new();
        private List<AdminStatsRepository.StatRow> _statVenit = new();

        public UCAdminDashboard()
        {
            InitializeComponent();
        }

        private void UCAdminDashboard_Load(object? sender, EventArgs e)
        {
            if (!SessionManager.EsteAdmin)
            {
                MessageBox.Show("Doar admin poate accesa aceasta pagina.", "Acces interzis",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Navigator.Back();
                return;
            }

            ConfigureazaColoaneUseri();
            ConfigureazaColoaneEvenimente();
            ReincarcaTot();
        }

        private void btnRefresh_Click(object? sender, EventArgs e) => ReincarcaTot();

        private void ReincarcaTot()
        {
            try
            {
                ReincarcaKpi();
                ReincarcaUseri();
                ReincarcaEvenimente();
                ReincarcaStatistici();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la incarcare: " + ex.Message);
            }
        }

        // ===================================================================
        // KPI CARDS
        // ===================================================================
        private void ReincarcaKpi()
        {
            var k = _stats.GetKpi();
            flowKpi.SuspendLayout();
            flowKpi.Controls.Clear();
            flowKpi.Controls.Add(BuildKpi("Useri", k.TotalUseri.ToString(), Color.FromArgb(49, 112, 249)));
            flowKpi.Controls.Add(BuildKpi("Useri suspendati", k.UseriSuspendati.ToString(), Color.FromArgb(229, 57, 53)));
            flowKpi.Controls.Add(BuildKpi("Evenimente", k.TotalEvenimente.ToString(), Color.FromArgb(33, 41, 73)));
            flowKpi.Controls.Add(BuildKpi("Ev. suspendate", k.EvenimenteSuspendate.ToString(), Color.FromArgb(229, 57, 53)));
            flowKpi.Controls.Add(BuildKpi("Bilete vandute", k.BileteVandute.ToString(), Color.FromArgb(5, 150, 105)));
            flowKpi.Controls.Add(BuildKpi("Venit total", $"{k.VenitTotal:N0} lei", Color.FromArgb(5, 150, 105)));
            flowKpi.ResumeLayout();
        }

        private static Panel BuildKpi(string title, string value, Color accent)
        {
            var p = new Panel
            {
                Width = 145,
                Height = 70,
                Margin = new Padding(0, 0, 8, 0),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            var lblT = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.Gray,
                Location = new Point(8, 6),
                Size = new Size(135, 16)
            };
            var lblV = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = accent,
                Location = new Point(8, 24),
                Size = new Size(135, 26)
            };
            var bar = new Panel
            {
                BackColor = accent,
                Location = new Point(0, 0),
                Size = new Size(4, 70)
            };
            p.Controls.Add(bar);
            p.Controls.Add(lblT);
            p.Controls.Add(lblV);
            return p;
        }

        // ===================================================================
        // TAB USERI
        // ===================================================================
        private void ConfigureazaColoaneUseri()
        {
            dgvUseri.Columns.Clear();
            dgvUseri.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id", HeaderText = "ID", DataPropertyName = "IdUser",
                FillWeight = 6, MinimumWidth = 50
            });
            dgvUseri.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nume", HeaderText = "Nume", DataPropertyName = "NumeComplet",
                FillWeight = 22, MinimumWidth = 130
            });
            dgvUseri.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email", HeaderText = "Email", DataPropertyName = "Email",
                FillWeight = 32, MinimumWidth = 180
            });
            dgvUseri.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Rol", HeaderText = "Rol",
                FillWeight = 10, MinimumWidth = 80
            });
            dgvUseri.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Companie", HeaderText = "Companie",
                FillWeight = 18, MinimumWidth = 120
            });
            dgvUseri.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Suspendat", HeaderText = "Suspendat", DataPropertyName = "EsteSuspendat",
                FillWeight = 12, MinimumWidth = 90
            });
            dgvUseri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUseri.CellFormatting += DgvUseri_CellFormatting;
        }

        private void DgvUseri_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvUseri.Rows.Count) return;
            if (dgvUseri.Rows[e.RowIndex].DataBoundItem is not Utilizator u) return;

            var col = dgvUseri.Columns[e.ColumnIndex].Name;
            if (col == "Rol")
            {
                e.Value = u.Rol.ToDbString();
                e.FormattingApplied = true;
            }
            else if (col == "Companie")
            {
                var c = u is Manager m ? m.Companie : null;
                e.Value = string.IsNullOrWhiteSpace(c) ? "-" : c;
                e.FormattingApplied = true;
            }
        }

        private void ReincarcaUseri()
        {
            // Memoram id-ul user-ului curent ca sa-l re-selectam dupa refresh
            var idCurent = GetSelectedUser()?.IdUser;

            var lista = _userRepo.GetAll();
            dgvUseri.DataSource = null;
            dgvUseri.DataSource = lista;

            // Re-selectam acelasi user daca exista in noua lista
            if (idCurent.HasValue)
            {
                for (int i = 0; i < dgvUseri.Rows.Count; i++)
                {
                    if (dgvUseri.Rows[i].DataBoundItem is Utilizator u && u.IdUser == idCurent.Value)
                    {
                        dgvUseri.ClearSelection();
                        dgvUseri.Rows[i].Selected = true;
                        dgvUseri.CurrentCell = dgvUseri.Rows[i].Cells[0];
                        break;
                    }
                }
            }

            // Forteaza actualizarea panel-ului pe baza selectiei curente
            // (SelectionChanged poate sa nu fi fost firat sincron dupa DataSource set)
            dgvUseri_SelectionChanged(this, EventArgs.Empty);
        }

        private void ResetUserPanel()
        {
            lblUserSelectat.Text = "Selecteaza un utilizator din tabel";
            btnSuspendaUser.Visible = false;
            btnActiveazaUser.Visible = false;
            btnEditUser.Enabled = false;
            btnAplicaRol.Enabled = false;
        }

        private void dgvUseri_SelectionChanged(object? sender, EventArgs e)
        {
            var u = GetSelectedUser();
            if (u == null) { ResetUserPanel(); return; }

            lblUserSelectat.Text =
                $"#{u.IdUser} {u.NumeComplet} | {u.Email} | Rol: {u.Rol.ToDbString()} | "
                + (u.EsteSuspendat ? "SUSPENDAT" : "Activ");
            cboRolNou.SelectedItem = u.Rol.ToDbString();

            // Vizibilitate exclusiva: Suspenda DOAR pe activi, Reactiveaza DOAR pe suspendati
            btnSuspendaUser.Visible  = !u.EsteSuspendat;
            btnActiveazaUser.Visible =  u.EsteSuspendat;
            btnEditUser.Enabled = true;
            btnAplicaRol.Enabled = true;
        }

        private Utilizator? GetSelectedUser()
            => dgvUseri.SelectedRows.Count > 0 ? dgvUseri.SelectedRows[0].DataBoundItem as Utilizator : null;

        private void btnSuspendaUser_Click(object? sender, EventArgs e)
        {
            var u = GetSelectedUser();
            if (u == null) return;
            if (u.IdUser == SessionManager.UtilizatorCurent!.IdUser)
            {
                MessageBox.Show("Nu te poti suspenda pe tine.", "Operatiune respinsa",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Sigur suspendam contul lui {u.NumeComplet}?\n\nUtilizatorul nu va mai putea sa se autentifice.",
                "Confirmare suspendare",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            _userRepo.SetSuspended(u.IdUser, true);
            ReincarcaUseri();
            ReincarcaKpi();
        }

        private void btnActiveazaUser_Click(object? sender, EventArgs e)
        {
            var u = GetSelectedUser();
            if (u == null) return;
            if (MessageBox.Show($"Sigur reactivam contul lui {u.NumeComplet}?\n\nUtilizatorul va putea sa se autentifice din nou.",
                "Confirmare reactivare",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            _userRepo.SetSuspended(u.IdUser, false);
            ReincarcaUseri();
            ReincarcaKpi();
        }

        private void btnEditUser_Click(object? sender, EventArgs e)
        {
            var u = GetSelectedUser();
            if (u == null) return;
            using var dlg = new UserEditForm(u);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                ReincarcaUseri();
            }
        }

        private void btnAplicaRol_Click(object? sender, EventArgs e)
        {
            var u = GetSelectedUser();
            if (u == null) return;
            var rolStr = cboRolNou.SelectedItem as string;
            if (string.IsNullOrEmpty(rolStr)) return;

            if (u.IdUser == SessionManager.UtilizatorCurent!.IdUser && rolStr != "admin")
            {
                MessageBox.Show("Nu iti poti retrograda propriul cont admin.", "Operatiune respinsa",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rolNou = RolUtilizatorExtensions.FromDbString(rolStr);
            if (rolNou == u.Rol)
            {
                MessageBox.Show("Rolul selectat este acelasi cu cel actual.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Schimbam rolul lui {u.NumeComplet} din '{u.Rol.ToDbString()}' in '{rolStr}'?",
                "Confirmare schimbare rol",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            _userRepo.UpdateRol(u.IdUser, rolNou);
            ReincarcaUseri();
            ReincarcaKpi();
            ReincarcaStatistici();
        }

        // ===================================================================
        // TAB EVENIMENTE
        // ===================================================================
        private void ConfigureazaColoaneEvenimente()
        {
            dgvEvenimente.Columns.Clear();
            dgvEvenimente.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id", HeaderText = "ID", DataPropertyName = "IdEvent",
                FillWeight = 5, MinimumWidth = 50
            });
            dgvEvenimente.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nume", HeaderText = "Nume", DataPropertyName = "Nume",
                FillWeight = 38, MinimumWidth = 220
            });
            dgvEvenimente.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tip", HeaderText = "Tip",
                FillWeight = 9, MinimumWidth = 70
            });
            dgvEvenimente.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Data", HeaderText = "Data",
                FillWeight = 16, MinimumWidth = 110
            });
            dgvEvenimente.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Oras", HeaderText = "Oras", DataPropertyName = "Oras",
                FillWeight = 14, MinimumWidth = 90
            });
            dgvEvenimente.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Suspendat", HeaderText = "Suspendat", DataPropertyName = "EsteSuspendat",
                FillWeight = 12, MinimumWidth = 90
            });
            dgvEvenimente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvenimente.CellFormatting += DgvEvenimente_CellFormatting;
        }

        private void DgvEvenimente_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvEvenimente.Rows.Count) return;
            if (dgvEvenimente.Rows[e.RowIndex].DataBoundItem is Eveniment ev)
            {
                var col = dgvEvenimente.Columns[e.ColumnIndex].Name;
                if (col == "Tip")
                {
                    e.Value = ev.Tip.ToDbString();
                    e.FormattingApplied = true;
                }
                else if (col == "Data")
                {
                    e.Value = ev.Data?.ToString("yyyy-MM-dd HH:mm") ?? "?";
                    e.FormattingApplied = true;
                }
            }
        }

        private void ReincarcaEvenimente()
        {
            var idCurent = GetSelectedEv()?.IdEvent;

            var lista = _evRepo.GetAllForAdmin();
            dgvEvenimente.DataSource = null;
            dgvEvenimente.DataSource = lista;

            if (idCurent.HasValue)
            {
                for (int i = 0; i < dgvEvenimente.Rows.Count; i++)
                {
                    if (dgvEvenimente.Rows[i].DataBoundItem is Eveniment ev && ev.IdEvent == idCurent.Value)
                    {
                        dgvEvenimente.ClearSelection();
                        dgvEvenimente.Rows[i].Selected = true;
                        dgvEvenimente.CurrentCell = dgvEvenimente.Rows[i].Cells[0];
                        break;
                    }
                }
            }

            dgvEvenimente_SelectionChanged(this, EventArgs.Empty);
        }

        private void ResetEvPanel()
        {
            lblEvenimentSelectat.Text = "Selecteaza un eveniment din tabel";
            btnSuspendaEv.Visible = false;
            btnActiveazaEv.Visible = false;
            btnEditeazaEv.Enabled = false;
        }

        private void dgvEvenimente_SelectionChanged(object? sender, EventArgs e)
        {
            var ev = GetSelectedEv();
            if (ev == null) { ResetEvPanel(); return; }

            lblEvenimentSelectat.Text =
                $"#{ev.IdEvent} {ev.Nume} | {ev.Tip.ToDbString()} | {ev.Oras} | "
                + $"{ev.Data:yyyy-MM-dd HH:mm} | {(ev.EsteSuspendat ? "SUSPENDAT" : "Activ")}";

            btnSuspendaEv.Visible  = !ev.EsteSuspendat;
            btnActiveazaEv.Visible =  ev.EsteSuspendat;
            btnEditeazaEv.Enabled = true;
        }

        private Eveniment? GetSelectedEv()
            => dgvEvenimente.SelectedRows.Count > 0 ? dgvEvenimente.SelectedRows[0].DataBoundItem as Eveniment : null;

        private void btnSuspendaEv_Click(object? sender, EventArgs e)
        {
            var ev = GetSelectedEv();
            if (ev == null) return;
            if (MessageBox.Show($"Sigur suspendam evenimentul '{ev.Nume}'?\n\nEvenimentul nu va mai aparea in lista publica.",
                "Confirmare suspendare",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            _evRepo.SetSuspended(ev.IdEvent, true);
            ReincarcaEvenimente();
            ReincarcaKpi();
        }

        private void btnActiveazaEv_Click(object? sender, EventArgs e)
        {
            var ev = GetSelectedEv();
            if (ev == null) return;
            if (MessageBox.Show($"Sigur reactivam evenimentul '{ev.Nume}'?\n\nEvenimentul va aparea din nou in lista publica.",
                "Confirmare reactivare",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            _evRepo.SetSuspended(ev.IdEvent, false);
            ReincarcaEvenimente();
            ReincarcaKpi();
        }

        private void btnEditeazaEv_Click(object? sender, EventArgs e)
        {
            var ev = GetSelectedEv();
            if (ev == null) return;
            Navigator.Show(new UCEditEvent(ev.IdEvent));
        }

        // ===================================================================
        // TAB STATISTICI - GRAFICE
        // ===================================================================
        private void ReincarcaStatistici()
        {
            _statTip = _stats.EvenimentePeTip();
            _statRol = _stats.UtilizatoriPeRol();
            _statTop = _stats.Top5EvenimenteDupaBilete();
            _statVenit = _stats.VenitPeLuna();
            panChartTip.Invalidate();
            panChartRol.Invalidate();
            panChartTopBilete.Invalidate();
            panChartVenit.Invalidate();
        }

        private void panChartTip_Paint(object? sender, PaintEventArgs e)
            => DesendBarChart(e.Graphics, panChartTip.ClientRectangle, _statTip, Color.FromArgb(49, 112, 249));

        private void panChartRol_Paint(object? sender, PaintEventArgs e)
            => DesendBarChart(e.Graphics, panChartRol.ClientRectangle, _statRol, Color.FromArgb(5, 150, 105));

        private void panChartTopBilete_Paint(object? sender, PaintEventArgs e)
            => DesendBarChart(e.Graphics, panChartTopBilete.ClientRectangle, _statTop, Color.FromArgb(33, 41, 73), horizontal: true);

        private void panChartVenit_Paint(object? sender, PaintEventArgs e)
            => DesendBarChart(e.Graphics, panChartVenit.ClientRectangle, _statVenit, Color.FromArgb(229, 57, 53), valueFormat: "N0");

        /// <summary>
        /// Desenare grafic bara simplu (vertical sau orizontal) cu axa si valori.
        /// </summary>
        private static void DesendBarChart(Graphics g, Rectangle area,
            List<AdminStatsRepository.StatRow> data, Color color,
            bool horizontal = false, string valueFormat = "N0")
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (data == null || data.Count == 0)
            {
                using var f = new Font("Segoe UI", 9.5F);
                using var b = new SolidBrush(Color.Gray);
                g.DrawString("Fara date", f, b, area, new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
                return;
            }

            var maxVal = Math.Max(1, data.Max(x => x.Value));
            using var labelFont = new Font("Segoe UI", 8.5F);
            using var valueFont = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            using var labelBrush = new SolidBrush(Color.FromArgb(60, 60, 60));
            using var barBrush = new SolidBrush(color);

            int padding = 10;
            int innerW = area.Width - 2 * padding;
            int innerH = area.Height - 2 * padding;

            if (!horizontal)
            {
                int n = data.Count;
                int barW = Math.Max(20, (innerW - 10 * (n - 1)) / n);
                int chartH = innerH - 40;
                int x = padding;
                foreach (var d in data)
                {
                    int barH = (int)(chartH * (d.Value / maxVal));
                    int y = padding + 18 + (chartH - barH);
                    g.FillRectangle(barBrush, x, y, barW, barH);
                    g.DrawString(d.Value.ToString(valueFormat), valueFont, labelBrush,
                        new RectangleF(x, padding, barW, 16),
                        new StringFormat { Alignment = StringAlignment.Center });
                    g.DrawString(d.Label, labelFont, labelBrush,
                        new RectangleF(x - 5, padding + 18 + chartH + 2, barW + 10, 18),
                        new StringFormat { Alignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter });
                    x += barW + 10;
                }
            }
            else
            {
                int n = data.Count;
                int rowH = innerH / Math.Max(n, 1);
                int labelW = 140;
                int chartW = innerW - labelW - 50;
                int y = padding;
                foreach (var d in data)
                {
                    int barW = (int)(chartW * (d.Value / maxVal));
                    g.DrawString(d.Label, labelFont, labelBrush,
                        new RectangleF(padding, y + 4, labelW, rowH - 8),
                        new StringFormat { Alignment = StringAlignment.Near, Trimming = StringTrimming.EllipsisCharacter });
                    g.FillRectangle(barBrush, padding + labelW, y + (rowH - 18) / 2, barW, 18);
                    g.DrawString(d.Value.ToString(valueFormat), valueFont, labelBrush,
                        new PointF(padding + labelW + barW + 4, y + (rowH - 18) / 2 + 2));
                    y += rowH;
                }
            }
        }
    }
}
