<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="TimeSheet_git.WebUserControl1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<script type="text/javascript">
$(document).ready(function() {
  $(".js-example-basic-single").select2();
});
</script>

<select runat="server" id="SSSS" class="js-example-basic-single" title="ff">
  <option value="AL">Alabama</option>
  <option value="WY">Wyoming</option>
  <option value="WY1">Wyoming</option>
</select>
