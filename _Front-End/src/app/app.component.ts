import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

	constructor
	(
		private _router: Router,
		private authService: AuthService,
	)
	{
	}

	ngOnInit() {
	}

}
