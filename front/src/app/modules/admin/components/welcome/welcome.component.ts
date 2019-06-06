import { Component, OnInit } from '@angular/core';
import { LoadingBarService } from '../../../../services/shared/ui/loading-bar.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {
    
  constructor(private loadingBarService: LoadingBarService) { }

  ngOnInit() {
   this.loadingBarService.hideLoadingBar();
  }
}
