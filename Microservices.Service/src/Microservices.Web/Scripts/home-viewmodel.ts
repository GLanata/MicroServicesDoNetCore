class HomeViewModel {

    ErrorMessage: KnockoutObservable<string> = ko.observable("");

    NewEventDate: KnockoutObservable<Date> = ko.observable(new Date());

    NewEventName: KnockoutObservable<string> = ko.observable("");

    CurrentEvents: KnockoutObservableArray<EventViewModel> = ko.observableArray([]);

    getCurrentEvents() {
        var self = this;

        $.get("http://localhost:5001/api/event/all", function (success: UserEvent[]) {
            self.CurrentEvents.removeAll();

            success.forEach(function (item, index, data) {

                var event = new EventViewModel(item.Name, item.Date);
                self.CurrentEvents.push(event);

            });
        });
    }

    createEvent() {
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
    }
}