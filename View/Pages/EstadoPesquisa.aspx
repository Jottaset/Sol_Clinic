<%@ Page Language="C#" Inherits="View.Pages.EstadoPesquisa" %>
<!DOCTYPE html>
<html>
    <head runat="server">
        <title>Default</title>
        <link type="text/css" rel="stylesheet" href="../Content/bootstrap.css" />
        <style>
            .posicaoButton{
                margin-top: 20px;
            }
        </style>
        
    </head>
    <body>
        <div class="container">
          <!-- #include file ="../menu.inc" -->
          
            <form id="principal" runat="server" class="form-horizontal">
               
                 <div class="form-group">
                   <div class="col-lg-12">
                    <div class="input-group">
                      <asp:Textbox runat="server" id="idEstado" autocomplete="off" placeholder="Digite o id do estado..." CssClass="form-control"/>
                      <span class="input-group-btn">
                        <asp:Button UseSubmitBehavior="false" runat="server" id="btnPesquisar" Text="Pesquisar" CssClass="btn btn-default" OnClick="btnPesquisaPorId" />
                      </span>
                    </div>
                  </div>
                </div>
                
               
                 <div class="panel panel-default">
                    <div class="panel-body">
                        
                        <asp:Label id="lblMensagem" runat="server"/>
                        
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label>Nome Estado</label>
                                <asp:Textbox runat="server"  id="nomeEstado" CssClass="form-control" />
                            </div>
                            <div class="col-sm-3">
                                <label>Sigla</label>
                                <asp:Textbox runat="server"  id="siglaEstado" CssClass="form-control" />
                            </div>
                        </div>    
                    </div>
                </div>
            </form>   
          
        </div> 
        <script src="../Scripts/jquery-1.9.1.js"></script>
        <script src="../Scripts/bootstrap.js"></script>
    </body>
</html>