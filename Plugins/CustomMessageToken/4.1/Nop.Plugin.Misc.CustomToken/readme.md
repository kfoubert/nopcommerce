# ﻿Custom Message Token

This plugin demonstrates how to add a custom message token for use with message templates. It will also list the custom message token in the available list.

## Installation

Copy *Nop.Plugin.Misc.CustomToken* to your *nopCommerce\Plugins* folder

Open your nopCommerce Solution in Visual Studio

Right-Click the *Plugins* folder and click *Add...* then *Existing Project...*

Select the project file: *Nop.Plugin.Misc.CustomToken\Nop.Plugin.Misc.CustomToken.csproj*

Right-click the *Nop.Plugin.Misc.CustomToken* folder and click *Build*

This will place the plugin into the *Presentation\Nop.web\Plugins* folder

Run your nopCommerce website, log into the Admin center, goto Configuration -> Plugins.

Find Custom Token plugin and install the plugin.

You can now edit an existing message template add the custom message token called %Custom.Message.Token.CallForInfo%

## How It Works

**CustomTokenPlugin.cs**

This file installs or uninstalls the language resource *Custom.Token.CallForInfo*

**CustomMessageTokenProvider.cs**

Extends the MessageTokenProvider and then overrides AddOrderTokens() and GetListOfAllowedTokens() methods. 

AddOrderTokens() method replaces the content of the email message with the custom message token. 

GetListOfAllowedTokens() method can be used to add the custom message token to the Show Allowed helper when editing a message token.

**DependancyRegistrar.cs**

This class registers the CustomMessageTokenProvider to nopCommerce so the class can extend and override MessageTokenProvider.

## How To Customize

Open CustomMessageTokenProvider.cs and add your own custom message tokens to the AddOrderTokens() and GetListOfAllowedTokens() methods. 

**AddOrderTokens()**

`string myCustomString = "Here's some text";`

`tokens.Add(new Token("my.custom.token", myCustomString, true));`

**GetListOfAllowedTokens()**

`allowedTokens.Add("%my.custom.token%");`

### Optional

You can add your own language resources in the CustomTokenPlugin.cs file. 

