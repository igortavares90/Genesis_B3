import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { Subject } from 'rxjs';
let AppComponent = class AppComponent {
    constructor(http, service) {
        this.http = http;
        this.service = service;
        this.title = 'CDB';
        this.error = new Subject();
        this.initialValue = 0;
        this.numberOfMonths = 0;
    }
    ngOnInit() {
    }
    getCDB() {
        {
            this.service.getCDB(this.initialValue, this.numberOfMonths).subscribe((data) => {
                this.model = data;
            }, (err) => { this.error.next(err); });
        }
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app-root',
        templateUrl: './app.component.html',
        styleUrls: ['./app.component.css']
    })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map