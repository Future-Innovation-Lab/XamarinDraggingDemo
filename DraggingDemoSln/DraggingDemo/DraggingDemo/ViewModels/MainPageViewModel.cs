using DraggingDemo.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace DraggingDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ThingToDrag _currentDraggedItem;

        private ObservableCollection<ThingToDrag> _draggingThings;
        public ObservableCollection<ThingToDrag> DraggingThings
        {
            get { return _draggingThings; }
            set { SetProperty(ref _draggingThings, value); }
        }

        private DelegateCommand<ThingToDrag> _dragStartCommand;
        public DelegateCommand<ThingToDrag> DragStartCommand =>
            _dragStartCommand ?? (_dragStartCommand = new DelegateCommand<ThingToDrag>(ExecuteDragStartCommand));


        private DelegateCommand _dropOverCommand;
        public DelegateCommand DropOverCommand =>
            _dropOverCommand ?? (_dropOverCommand = new DelegateCommand(ExecuteDropOverCommand));


        private string _draggedItemText;
        public string DraggedItemText
        {
            get { return _draggedItemText; }
            set { SetProperty(ref _draggedItemText, value); }
        }


        void ExecuteDropOverCommand()
        {
            // If you want to also remove the item from a list
            if (DraggingThings.Contains(_currentDraggedItem))
                DraggingThings.Remove(_currentDraggedItem);

            //Just setting a text property as example but can do anything you need to do with dropped item

            DraggedItemText = _currentDraggedItem.ThingDescription;


        }

        void ExecuteDragStartCommand(ThingToDrag thing)
        {
            _currentDraggedItem = thing;
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Xamarin Forms Drag Drop Demo";
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            DraggingThings = new ObservableCollection<ThingToDrag>();

            var thing = new ThingToDrag() { ThingName = "Thing 1", ThingDescription = "This is Thing 1" };

            DraggingThings.Add(thing);

            thing = new ThingToDrag() { ThingName = "Thing 2", ThingDescription = "This is Thing 2" };

            DraggingThings.Add(thing);


        }
    }
}
