webpackJsonp([1],{

/***/ 16:
/***/ (function(module, exports, __webpack_require__) {

__webpack_require__(1);
module.exports = __webpack_require__(17);


/***/ }),

/***/ 17:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Config", function() { return Config; });
var Config = /** @class */ (function () {
    function Config() {
    }
    // Endpoints
    Config.TOKEN_ENDPOINT = "/connect/token";
    Config.REVOCATION_ENDPOINT = "/connect/revocation";
    Config.USERINFO_ENDPOINT = "/connect/userinfo";
    Config.CLIENT_ID = "AngularSPA";
    Config.GRANT_TYPE = "password";
    Config.REFRESH_GRANT_TYPE = "refresh_token";
    // The Web API, refresh token (offline_access) & user info (openid profile roles).
    Config.SCOPE = "WebApi offline_access openid profile";
    // Items names for browser storage
    Config.TOKEN_NAME = "tmx_token";
    Config.REFRESH_TOKEN_NAME = "tmx_refresh_token";
    Config.USER_INFO_NAME = "tmx_user_unfo";
    Config.EXPIRES_NAME = "tmx_expires";
    Config.CAM_ENTRY_POINT = "/landing";
    Config.OKTA_LOGIN_REDIRECT_ALLOW = Config.CAM_ENTRY_POINT;
    return Config;
}());



/***/ })

},[16]);
//# sourceMappingURL=settings.js.map