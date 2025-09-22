# PassGen

This is a password generation tool I created as a fun project. By no means should this be used in a live application as more secure measures should be taken.

## Examples
### Using default ruleset:
```cs
PasswordFactory.GenerateValidPasswordFromDefaultRuleset();

PasswordFactory.GenerateMultipleValidPasswordsFromDefaultRuleset(5);
```
<img width="402" alt="image" src="https://github.com/JJWren/PassGen/assets/43586816/4392e14f-38a2-46b3-85f5-477026114f16">

### Using custom ruleset:
```cs
PasswordRuleset customRuleset = new()
{
    MaximumIdenticalConsecutiveCharacters = 3,
    PasswordLengthMaximum = 128,
    IncludeSpaces = true,
    DesiredLengthOfPassword = 128
};
PasswordFactory.GenerateValidPasswordWithNewRuleset(customRuleset);
```
<img width="904" alt="image" src="https://github.com/JJWren/PassGen/assets/43586816/a66245e8-8b33-430a-a2e5-1e88f70fb648">
