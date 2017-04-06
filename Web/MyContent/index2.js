/// <reference path="C:\Users\tomasz.janicki\Documents\Visual Studio 2015\Projects\WcfTest\Web\Scripts/knockout-3.4.2.js" />

function Page(id) {
    var self = this;
    self.id = id;
}

function Square(id, left, top) {
    var self = this;
    self.id = id;
    self.left = left;
    self.top = top;
}

function Index2ViewModel() {
    var self = this;

    self.loginVisible = window.ko.observable(true);
    self.logoutVisible = window.ko.observable(false);
    self.pagesVisible = window.ko.observable(false);
    self.squaresVisible = window.ko.observable(false);

    self.userName = window.ko.observable("");
    self.password = window.ko.observable("");

    self.pages = window.ko.observableArray([]);

    self.squares = window.ko.observableArray([]);

    self.chosenPageId = window.ko.observable(0);

    self.login = function () {
        var userName = self.userName();
        var password = self.password();
        var data = '{ "userName": "' + userName + '", "password": "' + password + '" }';
        ajaxPost("login", data,
        function () {
            self.loginVisible(false);
            self.logoutVisible(true);
            self.pagesVisible(true);
            self.squaresVisible(false);
            fillPages();
        },
        function() {
            alert("unable to login");    
        });
    };

    self.logout = function() {
        ajaxPost("logout", "",
        function () {
            self.loginVisible(true);
            self.logoutVisible(false);
            self.pagesVisible(false);
            self.squaresVisible(false);
        },
        function () {
            alert("unable to login");
        });
    }

    self.showPage = function (page) {
        self.chosenPageId(page.id);
        ajaxGet("whiteboardv2getsquares?page=" + self.chosenPageId(),
        function (data) {
            var items = [];
            $.each(data, function (i, item) {
                items.push(new Square(item.Id, item.Left, item.Top));
            });
            self.squares(items);
            self.loginVisible(false);
            self.logoutVisible(false);
            self.pagesVisible(false);
            self.squaresVisible(true);
        },
        function() {
            alert("unable to get squares");
        });
    }

    self.backToPages = function () {
        self.loginVisible(false);
        self.logoutVisible(true);
        self.pagesVisible(true);
        self.squaresVisible(false);
    }

    self.savePage = function() {
        alert("save page");
    }

    function fillPages() {
        ajaxGet("whiteboardv2getpages",
        function (data) {
            var items = [];
            $.each(data, function (i, item) {
                items.push(new Page(item));
            });
            self.pages(items);
        },
        function() {
           alert("unable to get pages"); 
        });
    }

    function ajaxPost(endpoint, data, doneFn, failFn) {
        $.ajax({
            method: "POST",
            url: "/wcfproxy/ServiceProxy.svc/" + endpoint,
            data: data,
            contentType: "application/json; charset=UTF-8"
        }).done(function(result) {
            doneFn(result);
        }).fail(function() {
            failFn();
        });
    }

    function ajaxGet(endpoint, doneFn, failFn) {
        $.ajax({
            method: "GET",
            url: "/wcfproxy/ServiceProxy.svc/" + endpoint,
            cache: false,
            contentType: "application/json; charset=UTF-8"
        }).done(function (result) {
            doneFn(result);
        }).fail(function () {
            failFn();
        });
    }
}

ko.applyBindings(new Index2ViewModel());