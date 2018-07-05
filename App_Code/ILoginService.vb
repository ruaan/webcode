Imports System.ServiceModel

<ServiceContract()>
Public Interface ILoginService

    <OperationContract()>
    Function LoginConfirm(UserName As String, Password As String) As String




End Interface
