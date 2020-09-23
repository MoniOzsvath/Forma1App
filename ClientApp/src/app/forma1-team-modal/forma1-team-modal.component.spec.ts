import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Forma1TeamModalComponent } from './forma1-team-modal.component';

describe('Forma1TeamModalComponent', () => {
  let component: Forma1TeamModalComponent;
  let fixture: ComponentFixture<Forma1TeamModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Forma1TeamModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Forma1TeamModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
