var FakeAjax = (function () {
    function FakeAjax() {
        this.oldAjax = $.ajax;
        var self = this;
        this.handlers = {};
        $.ajax = function (settings) {
            //var url = settings.url;
            //var handler = self.handlers[url];
            //if (!handler) {
            //    throw new Error("No fake handler registered for ajax URL: " + url + ", request: " +
            //        JSON.stringify(settings, null, "    "));
            //}

            var xhr = {
                fail: function () {
                }
            };

            var jsonToURI = function (json) { return encodeURIComponent(JSON.stringify(json)); }
            var uriToJSON = function (urijson) { return JSON.parse(decodeURIComponent(urijson)); }

            var uri = 'FakeAjax:' + settings.url + '?' + jsonToURI(settings.request);
            window.location.href = uri;

            var result = {Error: 'asdf'};// handler(settings);

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