import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
let AppService = class AppService {
    constructor(http) {
        this.http = http;
        this.error = new Subject();
        this.API = 'https://localhost:7143';
    }
    getCDB(InitialValue, NumberOfMonths) {
        return this.http.get(`${this.API}/CDB?InitialValue=${InitialValue}&NumberOfMonths=${NumberOfMonths}`);
    }
    ;
};
AppService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], AppService);
export { AppService };
//# sourceMappingURL=app.service.js.map