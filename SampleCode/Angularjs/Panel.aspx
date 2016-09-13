<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Panel.aspx.cs" Inherits="Angularjs.Panel" %>

    <!-- Angular Material style sheet -->
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/angular_material/1.1.0/angular-material.min.css">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <style>
          .demo-md-panel {
              min-height: 500px;
          }

          .demo-dialog-example {
              background: white;
              border-radius: 4px;
              box-shadow: 0 7px 8px -4px rgba(0, 0, 0, 0.2), 0 13px 19px 2px rgba(0, 0, 0, 0.14), 0 5px 24px 4px rgba(0, 0, 0, 0.12);
              width: 500px;
          }

          .demo-dialog-content {
              padding: 0 15px;
              width: 100%;
          }

              .demo-dialog-content img {
                  height: 300px;
                  margin: auto;
              }

          .demo-dialog-button {
              width: 100%;
          }

          .demo-menu-example {
              background: white;
              border-radius: 4px;
              box-shadow: 0 7px 8px -4px rgba(0, 0, 0, 0.2), 0 13px 19px 2px rgba(0, 0, 0, 0.14), 0 5px 24px 4px rgba(0, 0, 0, 0.12);
              width: 256px;
          }

          .demo-menu-item {
              align-items: center;
              cursor: pointer;
              display: flex;
              height: 48px;
              padding: 0 16px;
              position: relative;
              transition: background 0.15s linear;
              width: auto;
          }

              .demo-menu-item:hover,
              .demo-menu-item:focus {
                  background-color: rgb(238, 238, 238);
              }

              .demo-menu-item.selected {
                  color: rgb(16, 108, 200);
              }
      </style>
</head>
<body ng-app="panelDemo">
    <form id="form1" runat="server">
   <div class="demo-md-panel md-padding" ng-controller="BasicDemoCtrl as ctrl">
  <p>
    A panel can be used to create dialogs, menus, and other overlays.
  </p>
  <h2>Options</h2>
  <div layout="row">
    <div flex="33">
      <md-checkbox ng-model="ctrl.disableParentScroll">Disable Parent Scroll</md-checkbox
    </div>

  <div class="demo-md-panel-content">
    <md-button class="md-primary md-raised demo-dialog-open-button"
               ng-click="ctrl.showDialog($event)">
      Dialog
    </md-button>
    <md-button class="md-primary md-raised demo-menu-open-button"
               ng-click="ctrl.showMenu($event)">
      Select Menu
    </md-button>

    <p>Your favorite dessert is: {{ ctrl.selected.favoriteDessert }}</p>
  </div>
</div>
       </div>
    </form>
</body>
  
    <!-- Angular Material requires Angular.js Libraries -->
    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.5.5/angular.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.5.5/angular-animate.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.5.5/angular-aria.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.5.5/angular-messages.min.js"></script>

    <!-- Angular Material Library -->
    <script src="http://ajax.googleapis.com/ajax/libs/angular_material/1.1.0/angular-material.min.js"></script>


      <script type="text/javascript">
          (function () {
              'use strict';

              angular.module('panelDemo', ['ngMaterial'])
                  .controller('BasicDemoCtrl', BasicDemoCtrl)
                  .controller('PanelDialogCtrl', PanelDialogCtrl);

              function BasicDemoCtrl($mdPanel) {
                  this._mdPanel = $mdPanel;

                  this.desserts = [
                    'Apple Pie',
                    'Donut',
                    'Fudge',
                    'Cupcake',
                    'Ice Cream',
                    'Tiramisu'
                  ];

                  this.selected = { favoriteDessert: 'Donut' };
                  this.disableParentScroll = false;
              }

              BasicDemoCtrl.prototype.showDialog = function () {
                  var position = this._mdPanel.newPanelPosition()
                      .absolute()
                      .center();

                  var config = {
                      attachTo: angular.element(document.body),
                      controller: PanelDialogCtrl,
                      controllerAs: 'ctrl',
                      disableParentScroll: this.disableParentScroll,
                      templateUrl: 'panel.tmpl.html',
                      hasBackdrop: true,
                      panelClass: 'demo-dialog-example',
                      position: position,
                      trapFocus: true,
                      zIndex: 150,
                      clickOutsideToClose: true,
                      escapeToClose: true,
                      focusOnOpen: true
                  };

                  this._mdPanel.open(config);
              };

              BasicDemoCtrl.prototype.showMenu = function (ev) {
                  var position = this._mdPanel.newPanelPosition()
                      .relativeTo('.demo-menu-open-button')
                      .addPanelPosition(this._mdPanel.xPosition.ALIGN_START, this._mdPanel.yPosition.BELOW);

                  var config = {
                      attachTo: angular.element(document.body),
                      controller: PanelMenuCtrl,
                      controllerAs: 'ctrl',
                      template:
                          '<div class="demo-menu-example" ' +
                          '     aria-label="Select your favorite dessert." ' +
                          '     role="listbox">' +
                          '  <div class="demo-menu-item" ' +
                          '       ng-class="{selected : dessert == ctrl.favoriteDessert}" ' +
                          '       aria-selected="{{dessert == ctrl.favoriteDessert}}" ' +
                          '       tabindex="-1" ' +
                          '       role="option" ' +
                          '       ng-repeat="dessert in ctrl.desserts" ' +
                          '       ng-click="ctrl.selectDessert(dessert)"' +
                          '       ng-keydown="ctrl.onKeydown($event, dessert)">' +
                          '    {{ dessert }} ' +
                          '  </div>' +
                          '</div>',
                      panelClass: 'demo-menu-example',
                      position: position,
                      locals: {
                          'selected': this.selected,
                          'desserts': this.desserts
                      },
                      openFrom: ev,
                      clickOutsideToClose: true,
                      escapeToClose: true,
                      focusOnOpen: false,
                      zIndex: 2
                  };

                  this._mdPanel.open(config);
              };

              function PanelDialogCtrl(mdPanelRef) {
                  this._mdPanelRef = mdPanelRef;
              }

              PanelDialogCtrl.prototype.closeDialog = function () {
                  var panelRef = this._mdPanelRef;

                  panelRef && panelRef.close().then(function () {
                      angular.element(document.querySelector('.demo-dialog-open-button')).focus();
                      panelRef.destroy();
                  });
              };

              function PanelMenuCtrl(mdPanelRef, $timeout) {
                  this._mdPanelRef = mdPanelRef;
                  this.favoriteDessert = this.selected.favoriteDessert;
                  $timeout(function () {
                      var selected = document.querySelector('.demo-menu-item.selected');
                      if (selected) {
                          angular.element(selected).focus();
                      } else {
                          angular.element(document.querySelectorAll('.demo-menu-item')[0]).focus();
                      }
                  });
              }

              PanelMenuCtrl.prototype.selectDessert = function (dessert) {
                  this.selected.favoriteDessert = dessert;
                  this._mdPanelRef && this._mdPanelRef.close().then(function () {
                      angular.element(document.querySelector('.demo-menu-open-button')).focus();
                  });
              };

              PanelMenuCtrl.prototype.onKeydown = function ($event, dessert) {
                  var handled;
                  switch ($event.which) {
                      case 38: // Up Arrow.
                          var els = document.querySelectorAll('.demo-menu-item');
                          var index = indexOf(els, document.activeElement);
                          var prevIndex = (index + els.length - 1) % els.length;
                          els[prevIndex].focus();
                          handled = true;
                          break;

                      case 40: // Down Arrow.
                          var els = document.querySelectorAll('.demo-menu-item');
                          var index = indexOf(els, document.activeElement);
                          var nextIndex = (index + 1) % els.length;
                          els[nextIndex].focus();
                          handled = true;
                          break;

                      case 13: // Enter.
                      case 32: // Space.
                          this.selectDessert(dessert);
                          handled = true;
                          break;

                      case 9: // Tab.
                          this._mdPanelRef && this._mdPanelRef.close();
                  }

                  if (handled) {
                      $event.preventDefault();
                      $event.stopImmediatePropagation();
                  }

                  function indexOf(nodeList, element) {
                      for (var item, i = 0; item = nodeList[i]; i++) {
                          if (item === element) {
                              return i;
                          }
                      }
                      return -1;
                  }
              };

          })();
          </script>
</html>
