"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.ClientModule = void 0;
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var category_component_1 = require("./category/category.component");
var home_component_1 = require("./home/home.component");
var item_card_component_1 = require("./item-card/item-card.component");
var ClientModule = /** @class */ (function () {
    function ClientModule() {
    }
    ClientModule = __decorate([
        core_1.NgModule({
            declarations: [
                home_component_1.HomeComponent,
                category_component_1.CategoryComponent,
                item_card_component_1.ItemCardComponent
            ],
            imports: [
                common_1.CommonModule
            ],
            providers: []
        })
    ], ClientModule);
    return ClientModule;
}());
exports.ClientModule = ClientModule;
