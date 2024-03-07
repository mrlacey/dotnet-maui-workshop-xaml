namespace MonkeyFinder;

public partial class DetailsPage : VerticallyScrollingPage
{
    public DetailsPage(MonkeyDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}