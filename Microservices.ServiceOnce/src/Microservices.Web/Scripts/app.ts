class App {
    private _rootVm: Object;

    constructor(vm: Object) {
        this._rootVm = vm;

        ko.applyBindings(this._rootVm);
    }

    getRootVm() {
        return this._rootVm;
    }
}