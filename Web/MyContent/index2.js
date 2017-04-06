/// <reference path="C:\Users\tomasz.janicki\Documents\Visual Studio 2015\Projects\WcfTest\Web\Scripts/knockout-3.4.2.js" />

function Page(id) {
    var self = this;
    self.id = id;
}

function Square(id, left, top) {
    var self = this;
    self.id = window.ko.observable(id);
    self.left = window.ko.observable(left);
    self.top = window.ko.observable(top);
    self.leftPx = window.ko.observable(left + "px");
    self.topPx = window.ko.observable(top + "px");
}

function Index2ViewModel(hub) {
    var self = this;

    self.hub = hub;

    self.loginVisible = window.ko.observable(true);
    self.logoutVisible = window.ko.observable(false);
    self.pagesVisible = window.ko.observable(false);
    self.squaresVisible = window.ko.observable(false);

    self.userName = window.ko.observable("");
    self.password = window.ko.observable("");

    self.pages = window.ko.observableArray([]);

    self.squares = window.ko.observableArray([]);

    self.chosenPageId = window.ko.observable(0);

    self.squareDeleted = function(id) {
        alert(id);
    }

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
            self.hub.server.joinPage(self.chosenPageId());
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
        self.hub.server.leavePage(self.chosenPageId());
    }

    self.savePage = function() {
        var data = '{ "page": "' + self.chosenPageId() + '" }';
        ajaxPost("whiteboardv2savechanges", data,
        function() {
            alert("changes saved");
        },
        function() {
            alert("unable to save changes");
        });
    }

    self.addSquare = function() {
        var data = '{ "page": "' + self.chosenPageId() + '", "left": "0", "top": "0" }';
        ajaxPost("whiteboardv2insertsquare", data,
        function (result) {
            var id = result.WhiteBoardV2InsertSquareResult;
            self.squares.push(new Square(id, 0, 0));
        },
        function () {
            alert("unable to save changes");
        });
    }

    self.deleteSquare = function (square) {
        var id = square.id();
        var data = '{ "page": "' + self.chosenPageId() + '", "id": "' + id + '" }';
        ajaxPost("whiteboardv2deletesquare", data,
        function() {
            self.squares.remove(square);
            self.hub.server.squareDelete(id, self.chosenPageId());
        },
        function() {
            alert("unable to delete square");
        });
    }

    self.moveSquare = function (square, ui) {
        square.left(Math.round(ui.position.left));
        square.top(Math.round(ui.position.top));
        square.leftPx(Math.round(ui.position.left) + "px");
        square.topPx(Math.round(ui.position.top) + "px");
        var id = square.id();
        var left = square.left();
        var top = square.top();
        var data = '{ "page": "' + self.chosenPageId() + '", "square": { "Id" :"' + id + '", "Left": "' + left + '", "Top": "' + top + '"} }';
        ajaxPost("whiteboardv2updatesquare", data,
        function () {
        },
        function () {
            alert("unable to move square");
        });
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

$(function () {
    window.ko.bindingHandlers.draggable = {
        init: function (element, valueAccessor, allBindings, viewModel) {
            $(element).draggable({
                stop: function (event, ui) {
                    valueAccessor()(viewModel, ui);
                }
            });
        }
    };

    var whiteBoardHubV2 = $.connection.whiteBoardHubV2;

    var vm = new Index2ViewModel(whiteBoardHubV2);

    whiteBoardHubV2.client.squareDeleted = vm.squareDeleted;

    $.connection.hub.start().done(function() {
        window.ko.applyBindings(vm);
    });
});

