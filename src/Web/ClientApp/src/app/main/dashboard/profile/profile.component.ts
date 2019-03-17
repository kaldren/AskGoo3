import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProfileService } from 'src/app/_services/profile/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.less']
})
export class ProfileComponent implements OnInit, OnDestroy {
  id: number;
  profile: any;
  private sub: any;

  constructor(private route: ActivatedRoute, private profileService: ProfileService) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.getSingleMessageByUserId(+params.id);
    });
  }

  getSingleMessageByUserId(id: number) {
    this.profileService.getSingleProfileById(id)
    .subscribe((data) => {
      this.profile = data;
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
