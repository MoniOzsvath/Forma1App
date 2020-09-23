import { TestBed } from '@angular/core/testing';

import { Forma1TeamService } from './forma1-team.service';

describe('Forma1TeamService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: Forma1TeamService = TestBed.get(Forma1TeamService);
    expect(service).toBeTruthy();
  });
});
