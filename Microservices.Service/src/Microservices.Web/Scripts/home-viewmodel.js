var HomeViewModel = (function () {
    function HomeViewModel() {
        this.ErrorMessage = ko.observable("");
        this.NewEventDate = ko.observable(new Date());
        this.NewEventName = ko.observable("");
        this.CurrentEvents = ko.observableArray([]);
    }
    HomeViewModel.prototype.getCurrentEvents = function () {
        var self = this;
        $.get("http://localhost:5001/api/event/all", function (success) {
            self.CurrentEvents.removeAll();
            success.forEach(function (item, index, data) {
                var event = new EventViewModel(item.Name, item.Date);
                self.CurrentEvents.push(event);
            });
        });
    };
    HomeViewModel.prototype.createEvent = function () {
        var self = this;
        if (self.NewEventDate() < new Date()) {
            self.ErrorMessage("The selected date is in the past.");
            return;
        }
        var newEvent = new UserEvent();
        newEvent.Date = self.NewEventDate();
        newEvent.Name = self.NewEventName();
        $.post("http://localhost:5002/api/createevent/create", newEvent, function (result) {
            if (result)
                self.getCurrentEvents();
        });
    };
    return HomeViewModel;
}());
