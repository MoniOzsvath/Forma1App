import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Forma1TeamPageComponent } from './forma1-team-page.component';

describe('Forma1TeamPageComponent', () => {
  let component: Forma1TeamPageComponent;
  let fixture: ComponentFixture<Forma1TeamPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Forma1TeamPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Forma1TeamPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
