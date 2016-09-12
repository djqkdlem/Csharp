<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Bootstrap.Main" %>

<!DOCTYPE html>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/angular_material/1.1.0/angular-material.min.css">
    <title></title>
    <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>--%>
    <script src="https://code.jquery.com/jquery-1.12.0.min.js"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~")%>js/dropdown.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.5.5/angular.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.5.5/angular-animate.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.5.5/angular-aria.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.5.5/angular-messages.min.js"></script>
    <style>
        .bottomSheetdemoBasicUsage .md-inline-list-icon-label {
            display: inline-block;
            padding-left: 10px;
            padding-right: 10px;
            margin-top: -10px;
            height: 24px;
            vertical-align: middle;
        }

        .bottomSheetdemoBasicUsage .md-grid-item-content {
            height: 90px;
            padding-top: 10px;
        }

            .bottomSheetdemoBasicUsage .md-grid-item-content md-icon {
                height: 48px;
                width: 48px;
            }

        .bottomSheetdemoBasicUsage .md-grid-text {
            padding-bottom: 5px;
        }

        .bottomSheetdemoBasicUsage md-list-item, .bottomSheetdemoBasicUsage md-list-item .md-list-item-inner {
            min-height: 48px;
        }

        .bottomSheetdemoBasicUsage h2 {
            line-height: 36px;
            padding-top: 10px;
        }

        .bottomSheetdemoBasicUsage .md-subheader .md-subheader-inner {
            padding: 0;
        }

        .bottomSheetdemoBasicUsage md-toast .md-toast-content {
            background-color: #B14141;
        }

        .bottomSheetdemoBasicUsage md-toast > * {
            font-weight: bolder;
        }
    </style>
    <!-- Angular Material Library -->
    <script src="http://ajax.googleapis.com/ajax/libs/angular_material/1.1.0/angular-material.min.js"></script>
    <script type="text/ng-template" id="bottom-sheet-list-template.html">
    </script>

    <script type="text/javascript">
        //$().dropdown('toggle');
        //angular.module('BlankApp', ['ngMaterial']);

        angular.module('BlankApp', ['ngMaterial'])
.config(function ($mdIconProvider) {
    $mdIconProvider
      .icon('share-arrow', 'img/icons/share-arrow.svg', 24)
      .icon('upload', 'img/icons/upload.svg', 24)
      .icon('copy', 'img/icons/copy.svg', 24)
    //.icon('print', 'img/icons/print.svg', 24)
    //.icon('hangout', 'img/icons/hangout.svg', 24)
    //.icon('mail', 'img/icons/mail.svg', 24)
    //.icon('message', 'img/icons/message.svg', 24)
    //.icon('copy2', 'img/icons/copy2.svg', 24)
    //.icon('facebook', 'img/icons/facebook.svg', 24)
    //.icon('twitter', 'img/icons/twitter.svg', 24);
})
.controller('BottomSheetExample', function ($scope, $timeout, $mdBottomSheet, $mdToast) {
    $scope.alert = '';

    $scope.showGridBottomSheet = function () {
        $scope.alert = '';
        $mdBottomSheet.show({
            templateUrl: 'bottom-sheet-grid-template.html',
            controller: 'GridBottomSheetCtrl',
            clickOutsideToClose: false
        }).then(function (clickedItem) {
            $mdToast.show(
                  $mdToast.simple()
                    .textContent(clickedItem['name'] + ' clicked!')
                    .position('top right')
                    .hideDelay(1500)
                );
        });
    };
})
.controller('GridBottomSheetCtrl', function ($scope, $mdBottomSheet) {
    $scope.items = [
      { name: 'Hangout', icon: 'hangout' },
      { name: 'Mail', icon: 'mail' },
      { name: 'Message', icon: 'message' },
      //{ name: 'Copy', icon: 'copy2' },
      //{ name: 'Facebook', icon: 'facebook' },
      //{ name: 'Twitter', icon: 'twitter' },
    ];

    $scope.listItemClick = function ($index) {
        var clickedItem = $scope.items[$index];
        $mdBottomSheet.hide(clickedItem);
    };
})
.run(function ($templateRequest) {

    var urls = [
      'img/icons/share-arrow.svg',
      'img/icons/upload.svg',
      'img/icons/copy.svg',
      //'img/icons/print.svg',
      //'img/icons/hangout.svg',
      //'img/icons/mail.svg',
      //'img/icons/message.svg',
      //'img/icons/copy2.svg',
      //'img/icons/facebook.svg',
      //'img/icons/twitter.svg'
    ];

    angular.forEach(urls, function (url) {
        $templateRequest(url);
    });
});
    </script>
</head>
<body>
    <div class="row">
        <div class="col-sm-4">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Panel title<a class="anchorjs-link" href="#panel-title">
                        <div ng-app="BlankApp" ng-cloak>
                            <div ng-controller="BottomSheetExample" class="md-padding" ng-cloak>
                                <div class="bottom-sheet-demo inset" layout="row" layout-sm="column" layout-align="center">
                                    <md-button flex="50" class="md-primary md-raised" ng-click="showGridBottomSheet()">Show as Grid</md-button>
                                </div>

                                <div ng-if="alert">
                                    <br />
                                    <b layout="row" layout-align="center center" class="md-padding">{{alert}}
                                    </b>
                                </div>
                            </div>
                        </div>
                    </a></h3>


                </div>
                <div class="panel-body">
                    Panel content
                </div>
            </div>
        </div>
        <div class="col-sm-4">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <h3 class="panel-title">Panel title<a class="anchorjs-link" href="#panel-title"><span class="anchorjs-icon"></span></a></h3>
                </div>
                <div class="panel-body">
                    Panel content
                </div>
            </div>
        </div>
        <div class="col-sm-4">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">Panel title<a class="anchorjs-link" href="#panel-title"><span class="anchorjs-icon"></span></a></h3>
                </div>
                <div class="panel-body">
                    Panel content
                </div>
            </div>
        </div>
        <div class="col-sm-4">
            <div class="panel panel-warning">
                <div class="panel-heading">
                    <h3 class="panel-title">Panel title<a class="anchorjs-link" href="#panel-title"><span class="anchorjs-icon"></span></a></h3>
                </div>
                <div class="panel-body">
                    Panel content
                </div>
            </div>
        </div>
        <div class="col-sm-4">
            <div class="panel panel-danger">
                <div class="panel-heading">
                    <h3 class="panel-title">Panel title<a class="anchorjs-link" href="#panel-title"><span class="anchorjs-icon"></span></a></h3>
                </div>
                <div class="panel-body">
                    Panel content
                </div>
            </div>
        </div>
    </div>
</body>
</html>
