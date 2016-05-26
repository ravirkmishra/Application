var app = angular.module("ApplicationModule", ["ngRoute"]);

app.factory("ShareData", function () {
    return { value: 0 }
});

//Showing Routing  
app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    
    $routeProvider.when('/showstudents',
                        {
                            templateUrl: 'ManageStudentInfo/ShowStudents',
                            controller: 'ShowStudentsController'
                        });
    $routeProvider.when('/addstudent',
                        {
                            templateUrl: 'ManageStudentInfo/AddNewStudent',
                            controller: 'AddStudentController'
                        });
    $routeProvider.when("/editStudent",
                        {
                            templateUrl: 'ManageStudentInfo/EditStudent',
                            controller: 'EditStudentController'
                        });
    $routeProvider.when('/deleteStudent',
                        {
                            templateUrl: 'ManageStudentInfo/DeleteStudent',
                            controller: 'DeleteStudentController'
                        });
    $routeProvider.otherwise(
                        {
                            redirectTo: '/'
                        });

    $locationProvider.html5Mode(true).hashPrefix('!')
}]);