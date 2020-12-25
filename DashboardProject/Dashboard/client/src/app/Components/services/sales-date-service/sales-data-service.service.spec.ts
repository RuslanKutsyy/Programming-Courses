import { TestBed } from '@angular/core/testing';

import { SalesDataServiceService } from './sales-data-service.service';

describe('SalesDataServiceService', () => {
  let service: SalesDataServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalesDataServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
