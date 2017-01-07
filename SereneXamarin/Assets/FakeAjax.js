var FakeAjaxHandler = {};
var FakeXHR = {
    fail: function () {

    },
    abort: function () {

    }
};

var submitFakeAjaxResponse = function (requestedUrl, responseJson) {
    var response = JSON.parse(responseJson);
    FakeAjaxHandler[requestedUrl].success(response, '200', FakeXHR);
};

var FakeAjax = (function () {
    function FakeAjax() {
        this.oldAjax = $.ajax;
        Q.Config.applicationPath = 'fakeajax:';

        var self = this;
        this.handlers = {};
        $.ajax = function (settings) {
            //var url = settings.url;
            //var handler = self.handlers[url];
            //if (!handler) {
            //    throw new Error("No fake handler registered for ajax URL: " + url + ", request: " +
            //        JSON.stringify(settings, null, "    "));
            //}



            var jsonToURI = function (json) { return encodeURIComponent(JSON.stringify(json)); }
            var uriToJSON = function (urijson) { return JSON.parse(decodeURIComponent(urijson)); }
            if (settings.url && settings.url.substr(0, 2) === '~/') {
                settings.url = 'FakeAjax:' + settings.substr(2);
            }
            var uri = settings.url + '?' + jsonToURI(settings.request);
            window.location.href = uri;

            var result = {Error: 'asdf'};// handler(settings);

            FakeAjaxHandler[settings.url] = settings;
            var xhr = FakeXHR;
            //settings.success(result, '200', xhr);

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