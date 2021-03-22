<p align="center">+JMJ+</p>

## Program Logic Plan

### Classes

**Database**: a class to get and set info from the database
- log in to database
- get and set: 
  - words
  - definitions
  - comments
  - account info

**Dictionary** (implements iDatastore\<T\>): a class to get and set words from the dictionary. This class may not be needed.

**Accounts**: a class to manage accounts
- general functions:
  - create_account()
  - delete_account()
  - sign_in()
  - sign_out()
- data for current user
  - bool isAdmin
  - name: email, first name, last name
  - password
  - int rating
  - words[]
  - commands[]
  - upvotes[]
  - followed_accounts[]
  - make_comment()
  - delete_comment()
  - upvote(word)
  - undo_upvote(word)

**Filter**: a class to filter bad content out of definitions and comments.
- bool message_clean()

### Helper/Misc Functions
- set_theme()
- get_leaderboard()
- get_word_of_the_day()

### Database Tables
- **word**: word_id
- **definition**: definition_id, word_id
- **comment**: definition_id, (optional comment_id for replies)
- **account**: account_id, username (email?), password, first_name, last_name, 
