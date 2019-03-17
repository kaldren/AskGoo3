import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.less']
})
export class ProfileComponent implements OnInit, OnDestroy {
  id: number;
  content: string;
  message: any;
  private sub: any;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      // this.getSingleMessageByUserId(+params.id);
      this.id = +params.id;
    });
  }

  getSingleProfileById(id: number) {

  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
