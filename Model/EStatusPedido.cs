using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Model;

public enum EStatusPedido
{
    [EnumMember(Value = "Recebido")]
    Recebido,
    [EnumMember(Value = "EmPreparacao")]
    EmPreparacao,
    [EnumMember(Value = "Pronto")]
    Pronto,
    [EnumMember(Value = "Finalizado")]
    Finalizado
}
