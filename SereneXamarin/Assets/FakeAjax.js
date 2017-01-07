var FakeAjax = (function () {
    function FakeAjax() {
        this.oldAjax = $.ajax;
        var self = this;
        this.handlers = {};
        $.ajax = function (settings) {
            var url = settings.url;
            var handler = self.handlers[url];
            if (!handler) {
                throw new Error("No fake handler registered for ajax URL: " + url + ", request: " +
                    JSON.stringify(settings, null, "    "));
            }
            var xhr = {
                fail: function () {
                }
            };
            var result = handler(settings);
            settings.success(result, '200', xhr);
            return xhr;
        };
    }
    FakeAjax.prototype.addServiceHandler = function (service, handler) {
        this.handlers[Q.resolveUrl(service)] = handler;
    };
    FakeAjax.prototype.dispose = function () {
        $.ajax = this.oldAjax;
    };
    return FakeAjax;
}());

FakeAjax();