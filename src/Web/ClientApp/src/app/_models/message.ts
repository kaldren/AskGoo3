import { User } from './User';

export class Message {
  id: number;
  content: string;
  Recipient: User;
  Sender: User;
}
