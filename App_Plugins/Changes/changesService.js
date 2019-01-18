(function () {

    'use strict';

    function changesService($http) {
        
        var service = {
            getChanges: getChanges,
            getLanguages: getLanguages,
            getEditorInfo: getEditorInfo
        };

        return service;
        
        function getChanges(id) {
            return $http.get("/umbraco/backoffice/changes/changesapi/geteditedproperties?contentId=" + id);
        }

        function getLanguages() {
            return $http.get("/umbraco/backoffice/changes/changesapi/getlanguages");
        }

        function getEditorInfo(id) {
            return $http.get("/umbraco/backoffice/changes/changesapi/geteditorinfo?id=" + id);
        }
    }

    angular.module('umbraco.resources')
        .factory('changesService', changesService);

})();
