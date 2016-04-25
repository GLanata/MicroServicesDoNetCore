var EventViewModel = (function () {
    function EventViewModel(name, date) {
        this.Name = ko.observable(name);
        this.Date = ko.observable(date);
    }
    return EventViewModel;
}());
