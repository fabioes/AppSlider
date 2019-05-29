import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { timer } from 'rxjs';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-access-denied',
  templateUrl: './access-denied.component.html',
  styleUrls: ['./access-denied.component.scss']
})
export class AccessDeniedComponent implements OnInit {

  public decrementCount: number = 5;
  constructor(private router: Router) { }

  ngOnInit() {
    return timer(100, 1000).pipe(take(6)).subscribe((x) => {
      if (this.decrementCount > 0)
        this.decrementCount--;
      else
      this.router.navigateByUrl('/adm');
    });
  }
}
