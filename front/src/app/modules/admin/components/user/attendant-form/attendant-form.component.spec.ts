import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendantFormComponent } from './attendant-form.component';

describe('AttendantFormComponent', () => {
  let component: AttendantFormComponent;
  let fixture: ComponentFixture<AttendantFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AttendantFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AttendantFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
