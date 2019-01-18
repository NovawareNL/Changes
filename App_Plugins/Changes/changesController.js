(function () {

    'use strict';

    function changesController($scope, editorState, changesService, $routeParams) {

        var vm = this;

        vm.loading = true;
        vm.edited = true;
        
        vm.getChanges = getChanges;
        vm.getLanguages = getLanguages;
        vm.getEditorInfo = getEditorInfo;
        vm.selectLanguage = selectLanguage;
        vm.getLanguageCount = getLanguageCount;
        vm.refreshChanges = refreshChanges;
        vm.editorInfo = {};

        init();

        function init() {
            vm.refreshChanges();

            vm.noChangesLabel = vm.getLanguageCount(vm.selectLanguage) === 0;
        }

        function getLanguages() {
            changesService.getLanguages(editorState.current.id)
                .then(function (result) {
                        vm.languages = result.data;
                    },
                    function (error) {
                        console.log(error);
                    });
        }

        function getChanges() {
            changesService.getChanges(editorState.current.id)
                .then(function (result) {
                    vm.changes = result.data;
                },
                function(error) {
                    console.log(error);
                });
        }

        function getEditorInfo() {
            changesService.getEditorInfo(editorState.current.updater.id)
                .then(function (result) {
                        vm.editorInfo = result.data;
                        vm.editorInfo.UpdateDate = editorState.current.updateDate;
                    },
                    function (error) {
                        console.log(error);
                    });
        }

        function selectLanguage(isoCode) {
            vm.selectedLanguage = isoCode;
            if (vm.getLanguageCount(isoCode) > 0) {
                vm.noChangesLabel = true;
            } else {
                vm.noChangesLabel = false;
            }
        }

        function refreshChanges() {
            vm.loading = true;

            vm.selectedLanguage = $routeParams.mculture.toLowerCase();
            vm.getEditorInfo();
            vm.getLanguages();
            vm.getChanges();

            vm.loading = false;
        }
        
        $scope.$on("formSubmitted", function (ev, args) {
            console.log("Reload pending changes");
            vm.refreshChanges();
        });

        $scope.filterLanguage = function (property) {
            if (typeof property.Changes !== 'undefined' && property.Changes.length > 0) {
                return property.Changes.map(function(e) {
                     return e.Culture;
                }).indexOf(vm.selectedLanguage) > -1;
            }
            return false;
        };

        function getLanguageCount(isoCode) {
            var languageCount = 0;
            if (typeof vm.changes !== 'undefined') {
                for (var i = 0; i < vm.changes.length; i++) {
                    if (typeof vm.changes[i].Changes !== 'undefined') {
                        for (var j = 0; j < vm.changes[i].Changes.length; j++) {
                            if (vm.changes[i].Changes[j].Culture === isoCode) {
                                languageCount++;
                            }
                        }
                    }
                }
            }

            return languageCount;
        }

    }

    angular.module('umbraco')
        .controller("changesController", changesController);

})();

