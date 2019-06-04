import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BusinessTypeFormComponent } from './business-type-form.component';

describe('BusinessTypeFormComponent', () => {
  let component: BusinessTypeFormComponent;
  let fixture: ComponentFixture<BusinessTypeFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BusinessTypeFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BusinessTypeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
