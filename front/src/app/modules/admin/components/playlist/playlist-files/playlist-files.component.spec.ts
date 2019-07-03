import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlaylistFilesComponent } from './playlist-files.component';

describe('EstablishmentFormComponent', () => {
  let component: PlaylistFilesComponent;
  let fixture: ComponentFixture<PlaylistFilesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlaylistFilesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlaylistFilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
