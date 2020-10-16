"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Utils = void 0;
var environment_1 = require("../environments/environment");
var http_1 = require("@angular/common/http");
var rxjs_1 = require("rxjs");
var Utils = /** @class */ (function () {
    function Utils() {
    }
    Utils.errorHandler = function (error) {
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
    Utils.BASE_API_URL = environment_1.environment.BASE_API_URL;
    Utils.httpOptions = {
        headers: new http_1.HttpHeaders({
            'Content-Type': 'application/json'
        })
    };
    return Utils;
}());
exports.Utils = Utils;
