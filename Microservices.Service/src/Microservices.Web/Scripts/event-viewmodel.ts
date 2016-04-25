class EventViewModel {

    Name: KnockoutObservable<string>;

    Date: KnockoutObservable<Date>;

    constructor(name: string, date: Date) {
        this.Name = ko.observable(name);
        this.Date = ko.observable(date);
    }
}