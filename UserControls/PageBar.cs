namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    /// <summary>
    /// Bara de paginare reutilizabila: prev/next + info + selector dimensiune pagina.
    /// Hostul tine intreaga lista in memorie si foloseste <see cref="Slice{T}(IList{T})"/>
    /// pentru a obtine doar elementele paginii curente.
    /// </summary>
    public partial class PageBar : UserControl
    {
        private int _pageIndex;
        private int _pageSize = 12;
        private int _totalItems;

        /// <summary>Se ridica dupa orice schimbare de pagina sau dimensiune.</summary>
        public event Action? PageChanged;

        public int PageIndex => _pageIndex;
        public int PageSize => _pageSize;
        public int TotalItems => _totalItems;
        public int TotalPages => Math.Max(1, (int)Math.Ceiling((double)_totalItems / _pageSize));

        public PageBar()
        {
            InitializeComponent();
            cboSize.Items.Clear();
            cboSize.Items.AddRange(new object[] { 6, 12, 24, 48, 96 });
            cboSize.SelectedItem = _pageSize;
            cboSize.SelectedIndexChanged += CboSize_Changed;
            btnPrev.Click += (s, e) => GoToPage(_pageIndex - 1);
            btnNext.Click += (s, e) => GoToPage(_pageIndex + 1);
            UpdateUI();
        }

        /// <summary>Seteaza totalul si reseteaza pagina daca depaseste limitele.</summary>
        public void SetTotal(int total, bool fireEvent = true)
        {
            _totalItems = Math.Max(0, total);
            if (_pageIndex >= TotalPages) _pageIndex = Math.Max(0, TotalPages - 1);
            UpdateUI();
            if (fireEvent) PageChanged?.Invoke();
        }

        /// <summary>Slice-ul curent al listei pentru pagina activa.</summary>
        public IEnumerable<T> Slice<T>(IList<T> all)
        {
            int skip = _pageIndex * _pageSize;
            return all.Skip(skip).Take(_pageSize);
        }

        public void Reset()
        {
            _pageIndex = 0;
            UpdateUI();
        }

        private void GoToPage(int idx)
        {
            int newIdx = Math.Clamp(idx, 0, TotalPages - 1);
            if (newIdx == _pageIndex) return;
            _pageIndex = newIdx;
            UpdateUI();
            PageChanged?.Invoke();
        }

        private void CboSize_Changed(object? sender, EventArgs e)
        {
            if (cboSize.SelectedItem is int size && size != _pageSize)
            {
                _pageSize = size;
                _pageIndex = 0;
                UpdateUI();
                PageChanged?.Invoke();
            }
        }

        private void UpdateUI()
        {
            lblInfo.Text = _totalItems == 0
                ? "Niciun element"
                : $"Pagina {_pageIndex + 1} din {TotalPages}  •  {_totalItems} elemente";
            btnPrev.Enabled = _pageIndex > 0;
            btnNext.Enabled = _pageIndex < TotalPages - 1;
        }
    }
}
