var App = (function () {
    function App(vm) {
        this._rootVm = vm;
        ko.applyBindings(this._rootVm);
    }
    App.prototype.getRootVm = function () {
        return this._rootVm;
    };
    return App;
}());
