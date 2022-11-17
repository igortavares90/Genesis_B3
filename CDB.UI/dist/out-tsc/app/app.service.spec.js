import { TestBed } from '@angular/core/testing';
import { AppService } from './app.service';
describe('AppService', () => {
    let service;
    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(AppService);
    });
    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=app.service.spec.js.map