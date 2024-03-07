namespace MonkeyFinder.Controls;

[ContentProperty(nameof(Children))]
public class VerticallyScrollingPage : ContentPage
{
    private readonly ScrollView scrollView;
    private readonly VerticalStackLayout verticalLayout;

    public VerticallyScrollingPage()
    {
        verticalLayout = new VerticalStackLayout { Padding = 0 };
        scrollView = new ScrollView
        {
            Content = verticalLayout
        };

        base.Content = scrollView;
    }

    public IList<IView> Children
    {
        get => (IList<IView>)GetValue(ChildrenProperty);
        set => SetValue(ChildrenProperty, value);
    }

    public static readonly BindableProperty ChildrenProperty =
        BindableProperty.Create(nameof(Children), typeof(IList<IView>), typeof(VerticallyScrollingPage), null, propertyChanged: ChildrenChanged);

    private static void ChildrenChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is VerticallyScrollingPage b && newValue is IView newView)
        {
            b.verticalLayout.Children.Add(newView);
        }
    }
}
