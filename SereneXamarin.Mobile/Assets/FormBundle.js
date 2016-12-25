Q.ScriptData.set('Form.Membership.ResetPassword', [{"name":"NewPassword","title":"New Password","editorType":"Password","required":true,"width":80,"filteringType":"Editor","filteringParams":{"editorType":"Password","useLike":true}},{"name":"ConfirmPassword","title":"Confirm Password","editorType":"Password","required":true,"width":80,"filteringType":"Editor","filteringParams":{"editorType":"Password","useLike":true}}]);



Q.ScriptData.set('Form.Membership.ForgotPassword', [{"name":"Email","title":"E-mail Address","editorType":"Email","required":true,"width":80,"filteringType":"Editor","filteringParams":{"editorType":"Email","useLike":true}}]);



Q.ScriptData.set('Form.Membership.ChangePassword', [{"name":"OldPassword","title":"Current Password","editorType":"Password","required":true,"width":80,"filteringType":"Editor","filteringParams":{"editorType":"Password","useLike":true}},{"name":"NewPassword","title":"New Password","editorType":"Password","required":true,"width":80,"filteringType":"Editor","filteringParams":{"editorType":"Password","useLike":true}},{"name":"ConfirmPassword","title":"Confirm Password","editorType":"Password","required":true,"width":80,"filteringType":"Editor","filteringParams":{"editorType":"Password","useLike":true}}]);



Q.ScriptData.set('Form.Membership.SignUp', [{"name":"DisplayName","title":"DisplayName","placeholder":"Full name","required":true,"width":80},{"name":"Email","title":"Email","placeholder":"Email","editorType":"Email","required":true,"width":80,"filteringType":"Editor","filteringParams":{"editorType":"Email","useLike":true}},{"name":"ConfirmEmail","title":"ConfirmEmail","placeholder":"Confirm email","editorType":"Email","required":true,"width":80,"filteringType":"Editor","filteringParams":{"editorType":"Email","useLike":true}},{"name":"Password","title":"Password","placeholder":"Password","editorType":"Password","required":true,"width":80,"filteringType":"Editor","filteringParams":{"editorType":"Password","useLike":true}},{"name":"ConfirmPassword","title":"ConfirmPassword","placeholder":"Confirm password","editorType":"Password","required":true,"width":80,"filteringType":"Editor","filteringParams":{"editorType":"Password","useLike":true}}]);



Q.ScriptData.set('Form.Membership.Login', [{"name":"Username","title":"Db.Administration.User.Username","placeholder":"default username is 'admin'","editorParams":{"maxLength":100},"maxLength":100,"required":true,"width":150},{"name":"Password","title":"Db.Administration.User.Password","placeholder":"default password for 'admin' is 'serenity'","editorType":"Password","editorParams":{"maxLength":50},"maxLength":50,"required":true,"width":150,"sortable":false,"filteringType":"Editor","filteringParams":{"editorType":"Password","useLike":true},"notFilterable":true}]);



Q.ScriptData.set('Form.Administration.User', [{"name":"Username","title":"Db.Administration.User.Username","editorParams":{"maxLength":100},"maxLength":100,"required":true,"width":150},{"name":"DisplayName","title":"Db.Administration.User.DisplayName","editorParams":{"maxLength":100},"maxLength":100,"required":true,"width":150},{"name":"Email","title":"Db.Administration.User.Email","editorType":"Email","editorParams":{"maxLength":100},"maxLength":100,"width":150,"filteringType":"Editor","filteringParams":{"editorType":"Email","useLike":true}},{"name":"UserImage","title":"Db.Administration.User.UserImage","editorType":"ImageUpload","editorParams":{"maxLength":100},"maxLength":100,"width":150,"filteringType":"Editor","filteringParams":{"editorType":"ImageUpload","useLike":true}},{"name":"Password","title":"Db.Administration.User.Password","editorType":"Password","editorParams":{"maxLength":50},"maxLength":50,"required":true,"width":150,"sortable":false,"filteringType":"Editor","filteringParams":{"editorType":"Password","useLike":true},"notFilterable":true},{"name":"PasswordConfirm","title":"Db.Administration.User.PasswordConfirm","editorType":"Password","editorParams":{"maxLength":50},"maxLength":50,"required":true,"oneWay":true,"width":150,"sortable":false,"filteringType":"Editor","filteringParams":{"editorType":"Password","useLike":true},"notFilterable":true},{"name":"Source","title":"Db.Administration.User.Source","editorParams":{"maxLength":4},"maxLength":4,"required":true,"insertable":false,"updatable":false,"oneWay":true,"defaultValue":"site","width":150}]);



Q.ScriptData.set('Form.Administration.Language', [{"name":"LanguageId","title":"Db.Administration.Language.LanguageId","editorParams":{"maxLength":10},"maxLength":10,"required":true,"width":150},{"name":"LanguageName","title":"Db.Administration.Language.LanguageName","editorParams":{"maxLength":50},"maxLength":50,"required":true,"width":150}]);



Q.ScriptData.set('Form.Administration.Role', [{"name":"RoleName","title":"Db.Administration.Role.RoleName","editorParams":{"maxLength":100},"maxLength":100,"required":true,"width":150}]);



