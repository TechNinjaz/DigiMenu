"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AppUtils = void 0;
var http_1 = require("@angular/common/http");
var rxjs_1 = require("rxjs");
var environment_1 = require("../../../environments/environment");
var AppUtils = /** @class */ (function () {
    function AppUtils() {
    }
    AppUtils.errorHandler = function (error) {
        var errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            errorMessage = error.error.message;
        }
        else {
            errorMessage = "Error Code: " + error.status + "\nMessage: " + error.message;
        }
        console.log(errorMessage);
        return rxjs_1.throwError(errorMessage);
    };
    AppUtils.BASE_API_URL = environment_1.environment.BASE_API_URL;
    AppUtils.httpOptions = {
        headers: new http_1.HttpHeaders({
            'Content-Type': 'application/json'
        })
    };
    return AppUtils;
}());
exports.AppUtils = AppUtils;
