using System.Windows.Input;

namespace LabTest;

public partial class Q3 : ContentPage
{

    private readonly PostViewModel _viewModel;

    public Q3()
    {
        InitializeComponent();

        _viewModel = DependencyService.Get<PostViewModel>();
        BindingContext = _viewModel;
    }

    // Add the following commands to the MainPage.xaml.cs
    public ICommand EditCommand => new Command<int>(async (postId) => await EditPost(postId));
    public ICommand DeleteCommand => new Command<int>(async (postId) => await DeletePost(postId));
    public ICommand AddOrUpdateCommand => new Command(async () => await AddOrUpdatePost());

    private async Task EditPost(int postId)
    {
        // Fetch the post by ID and populate the UI for editing
        var post = await _viewModel.GetPostById(postId);
        _viewModel.NewPostTitle = post.Title;
        _viewModel.NewPostBody = post.Body;
    }

    private async Task DeletePost(int postId)
    {
        var result = await DisplayAlert("Confirmation", "Are you sure you want to delete this post?", "Yes", "No");
        if (result)
        {
            await _viewModel.DeletePost(postId);
        }
    }

    private async Task AddOrUpdatePost()
    {
        // Create a new PostRecord with the entered data
        var newPost = new PostRecord
        {
            Title = _viewModel.NewPostTitle,
            Body = _viewModel.NewPostBody
        };

        // Call the ViewModel method to add or update the post
        await _viewModel.AddOrUpdatePost(newPost);

        // Clear the input fields after adding or updating
        _viewModel.NewPostTitle = string.Empty;
        _viewModel.NewPostBody = string.Empty;
    }

}