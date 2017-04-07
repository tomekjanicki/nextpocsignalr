function SimpleSquare(id, left, top) {
    var self = this;
    self.Id = id;
    self.Left = left;
    self.Top = top;
}

function Page(id) {
    var self = this;
    self.id = id;
}

function Square(id, left, top) {
    var self = this;
    self.id = window.ko.observable(id);
    self.left = window.ko.observable(Math.round(left));
    self.top = window.ko.observable(Math.round(top));
    self.leftPx = window.ko.observable(Math.round(left) + "px");
    self.topPx = window.ko.observable(Math.round(top) + "px");
}

function Index2ViewModel(hub, baseUrl) {
    var self = this;

    self.hub = hub;
    self.baseUrl = baseUrl;

    self.savedPageChosen = false;

    self.loginVisible = window.ko.observable(true);
    self.logoutVisible = window.ko.observable(false);
    self.pagesVisible = window.ko.observable(false);
    self.squaresVisible = window.ko.observable(false);
    self.savedSquaresVisible = window.ko.observable(false);

    self.userName = window.ko.observable("");
    self.password = window.ko.observable("");

    self.pages = window.ko.observableArray([]);

    self.squares = window.ko.observableArray([]);

    self.chosenPageId = window.ko.observable(0);

    self.squareDeleted = function (id) {
        self.squares.remove(function (square) {
            var isTrue = square.id() === id;
            return isTrue;
        });
    }

    self.squareMoved = function (square) {

        var id = square.Id;

        var s = window.ko.utils.arrayFirst(self.squares(), function (item) {
            var isTrue = item.id() === id;
            return isTrue;
        });

        if (s != null) {
            updateSquare(s, square.Left, square.Top);
        }
    }

    self.squareAdded = function (square) {
        var s = new Square(square.Id, square.Left, square.Top);
        self.squares.push(s);
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
            self.savedSquaresVisible(false);
            fillPages();
        },
        function () {
            alert("unable to login");
        });
    };

    self.logout = function () {
        ajaxPost("logout", "",
        function () {
            self.loginVisible(true);
            self.logoutVisible(false);
            self.pagesVisible(false);
            self.squaresVisible(false);
            self.savedSquaresVisible(false);
        },
        function () {
            alert("unable to login");
        });
    }

    self.showPage = function (page) {
        var pageId = page.id;
        self.chosenPageId(pageId);
        ajaxGet("whiteboardv2getsquares?page=" + pageId,
        function (data) {
            self.savedPageChosen = false;
            var items = [];
            $.each(data, function (i, item) {
                items.push(new Square(item.Id, item.Left, item.Top));
            });
            self.squares(items);
            self.loginVisible(false);
            self.logoutVisible(false);
            self.pagesVisible(false);
            self.squaresVisible(true);
            self.savedSquaresVisible(false);
            self.hub.server.joinPage(pageId);
        },
        function () {
            alert("unable to get squares");
        });
    }

    self.showSavedPage = function (page) {
        var pageId = page.id;
        self.chosenPageId(pageId);
        ajaxGet("whiteboardv2getsavedsquares?page=" + pageId,
        function (data) {
            self.savedPageChosen = true;
            var items = [];
            $.each(data, function (i, item) {
                items.push(new Square(item.Id, item.Left, item.Top));
            });
            self.squares(items);
            self.loginVisible(false);
            self.logoutVisible(false);
            self.pagesVisible(false);
            self.squaresVisible(false);
            self.savedSquaresVisible(true);
        },
        function () {
            alert("unable to get saved squares");
        });
    }

    self.backToPages = function () {
        var pageId = self.chosenPageId();
        self.loginVisible(false);
        self.logoutVisible(true);
        self.pagesVisible(true);
        self.squaresVisible(false);
        self.savedSquaresVisible(false);
        var shouldCallLeavePage = !self.savedPageChosen;
        self.savedPageChosen = false;
        if (shouldCallLeavePage) {
            self.hub.server.leavePage(pageId);
        }        
    }

    self.savePage = function () {
        var pageId = self.chosenPageId();
        var data = '{ "page": "' + pageId + '" }';
        ajaxPost("whiteboardv2savechanges", data,
        function () {
            alert("changes saved");
        },
        function () {
            alert("unable to save changes");
        });
    }

    self.addSquare = function () {
        var left = 0;
        var top = 0;
        var pageId = self.chosenPageId();
        var data = '{ "page": "' + pageId + '", "left": "' + left + '", "top": "' + top + '" }';
        ajaxPost("whiteboardv2insertsquare", data,
        function (result) {
            var id = result.WhiteBoardV2InsertSquareResult;
            self.squares.push(new Square(id, left, top));
            var simpleSquare = new SimpleSquare(id, left, top);
            self.hub.server.squareAdd(simpleSquare, pageId);
        },
        function () {
            alert("unable to save changes");
        });
    }

    self.deleteSquare = function (square) {
        var id = square.id();
        var pageId = self.chosenPageId();
        var data = '{ "page": "' + pageId + '", "id": "' + id + '" }';
        ajaxPost("whiteboardv2deletesquare", data,
        function () {
            self.squares.remove(square);
            self.hub.server.squareDelete(id, pageId);
        },
        function () {
            alert("unable to delete square");
        });
    }

    self.moveSquare = function (square, ui) {
        updateSquare(square, ui.position.left, ui.position.top);
        var id = square.id();
        var left = square.left();
        var top = square.top();
        var pageId = self.chosenPageId();
        var data = '{ "page": "' + pageId + '", "square": { "Id" :"' + id + '", "Left": "' + left + '", "Top": "' + top + '"} }';
        ajaxPost("whiteboardv2updatesquare", data,
        function () {
            var simpleSquare = new SimpleSquare(id, left, top);
            self.hub.server.squareMove(simpleSquare, pageId);
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
        function () {
            alert("unable to get pages");
        });
    }

    function ajaxPost(endpoint, data, doneFn, failFn) {
        $.ajax({
            method: "POST",
            url: self.baseUrl + endpoint,
            data: data,
            contentType: "application/json; charset=UTF-8"
        }).done(function (result) {
            doneFn(result);
        }).fail(function () {
            failFn();
        });
    }

    function ajaxGet(endpoint, doneFn, failFn) {
        $.ajax({
            method: "GET",
            url: self.baseUrl + endpoint,
            cache: false,
            contentType: "application/json; charset=UTF-8"
        }).done(function (result) {
            doneFn(result);
        }).fail(function () {
            failFn();
        });
    }

    function updateSquare(square, left, top) {
        square.left(Math.round(left));
        square.top(Math.round(top));
        square.leftPx(Math.round(left) + "px");
        square.topPx(Math.round(top) + "px");
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

    var vm = new Index2ViewModel(whiteBoardHubV2, "/wcfproxy/ServiceProxy.svc/");

    whiteBoardHubV2.client.squareDeleted = vm.squareDeleted;

    whiteBoardHubV2.client.squareMoved = vm.squareMoved;

    whiteBoardHubV2.client.squareAdded = vm.squareAdded;

    $.connection.hub.start().done(function () {
        window.ko.applyBindings(vm);
    });
});

