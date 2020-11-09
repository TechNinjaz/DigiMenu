"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.MenuCategoryService = void 0;
var core_1 = require("@angular/core");
var AppUtils_1 = require("../util/AppUtils");
var operators_1 = require("rxjs/operators");
var MenuCategoryService = /** @class */ (function () {
    function MenuCategoryService(http) {
        this.http = http;
        this.BaseUrl = AppUtils_1.AppUtils.BASE_API_URL + '/api/MenuCategory/';
    }
    MenuCategoryService.prototype.getCategory = function (id) {
        return this.http.get(this.BaseUrl + ("GetById/" + id), AppUtils_1.AppUtils.httpOptions)
            .pipe(operators_1.retry(1), operators_1.catchError(AppUtils_1.AppUtils.errorHandler));
    };
    MenuCategoryService.prototype.getCategoryList = function () {
        return this.http.get(this.BaseUrl + 'GetAll', AppUtils_1.AppUtils.httpOptions)
            .pipe(operators_1.retry(1), operators_1.catchError(AppUtils_1.AppUtils.errorHandler));
    };
    MenuCategoryService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        })
    ], MenuCategoryService);
    return MenuCategoryService;
}());
exports.MenuCategoryService = MenuCategoryService;
