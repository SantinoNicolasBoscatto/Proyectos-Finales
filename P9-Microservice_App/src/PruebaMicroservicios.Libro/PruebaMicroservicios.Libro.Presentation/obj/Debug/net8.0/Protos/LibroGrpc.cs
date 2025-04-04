// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/libro.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace PruebaMicroservicios.Libro.Presentation {
  public static partial class Libro
  {
    static readonly string __ServiceName = "Libro";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::PruebaMicroservicios.Libro.Presentation.GetLibroByIdRequest> __Marshaller_GetLibroByIdRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::PruebaMicroservicios.Libro.Presentation.GetLibroByIdRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::PruebaMicroservicios.Libro.Presentation.GetLibroByIdResponse> __Marshaller_GetLibroByIdResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::PruebaMicroservicios.Libro.Presentation.GetLibroByIdResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::PruebaMicroservicios.Libro.Presentation.GetAllLibroRequest> __Marshaller_GetAllLibroRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::PruebaMicroservicios.Libro.Presentation.GetAllLibroRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::PruebaMicroservicios.Libro.Presentation.GetAllLibroResponse> __Marshaller_GetAllLibroResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::PruebaMicroservicios.Libro.Presentation.GetAllLibroResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::PruebaMicroservicios.Libro.Presentation.GetAllLibroByAutorRequest> __Marshaller_GetAllLibroByAutorRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::PruebaMicroservicios.Libro.Presentation.GetAllLibroByAutorRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::PruebaMicroservicios.Libro.Presentation.GetAllLibroByAutorResponse> __Marshaller_GetAllLibroByAutorResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::PruebaMicroservicios.Libro.Presentation.GetAllLibroByAutorResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::PruebaMicroservicios.Libro.Presentation.CreateLibroRequest> __Marshaller_CreateLibroRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::PruebaMicroservicios.Libro.Presentation.CreateLibroRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::PruebaMicroservicios.Libro.Presentation.CreateLibroResponse> __Marshaller_CreateLibroResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::PruebaMicroservicios.Libro.Presentation.CreateLibroResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::PruebaMicroservicios.Libro.Presentation.UpdateLibroRequest> __Marshaller_UpdateLibroRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::PruebaMicroservicios.Libro.Presentation.UpdateLibroRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::PruebaMicroservicios.Libro.Presentation.UpdateLibroResponse> __Marshaller_UpdateLibroResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::PruebaMicroservicios.Libro.Presentation.UpdateLibroResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::PruebaMicroservicios.Libro.Presentation.DeleteLibroRequest> __Marshaller_DeleteLibroRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::PruebaMicroservicios.Libro.Presentation.DeleteLibroRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::PruebaMicroservicios.Libro.Presentation.DeleteLibroResponse> __Marshaller_DeleteLibroResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::PruebaMicroservicios.Libro.Presentation.DeleteLibroResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::PruebaMicroservicios.Libro.Presentation.GetLibroByIdRequest, global::PruebaMicroservicios.Libro.Presentation.GetLibroByIdResponse> __Method_GetLibro = new grpc::Method<global::PruebaMicroservicios.Libro.Presentation.GetLibroByIdRequest, global::PruebaMicroservicios.Libro.Presentation.GetLibroByIdResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetLibro",
        __Marshaller_GetLibroByIdRequest,
        __Marshaller_GetLibroByIdResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::PruebaMicroservicios.Libro.Presentation.GetAllLibroRequest, global::PruebaMicroservicios.Libro.Presentation.GetAllLibroResponse> __Method_GetAllLibro = new grpc::Method<global::PruebaMicroservicios.Libro.Presentation.GetAllLibroRequest, global::PruebaMicroservicios.Libro.Presentation.GetAllLibroResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllLibro",
        __Marshaller_GetAllLibroRequest,
        __Marshaller_GetAllLibroResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::PruebaMicroservicios.Libro.Presentation.GetAllLibroByAutorRequest, global::PruebaMicroservicios.Libro.Presentation.GetAllLibroByAutorResponse> __Method_GetAllLibroByAutor = new grpc::Method<global::PruebaMicroservicios.Libro.Presentation.GetAllLibroByAutorRequest, global::PruebaMicroservicios.Libro.Presentation.GetAllLibroByAutorResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllLibroByAutor",
        __Marshaller_GetAllLibroByAutorRequest,
        __Marshaller_GetAllLibroByAutorResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::PruebaMicroservicios.Libro.Presentation.CreateLibroRequest, global::PruebaMicroservicios.Libro.Presentation.CreateLibroResponse> __Method_CreateLibro = new grpc::Method<global::PruebaMicroservicios.Libro.Presentation.CreateLibroRequest, global::PruebaMicroservicios.Libro.Presentation.CreateLibroResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateLibro",
        __Marshaller_CreateLibroRequest,
        __Marshaller_CreateLibroResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::PruebaMicroservicios.Libro.Presentation.UpdateLibroRequest, global::PruebaMicroservicios.Libro.Presentation.UpdateLibroResponse> __Method_UpdateLibro = new grpc::Method<global::PruebaMicroservicios.Libro.Presentation.UpdateLibroRequest, global::PruebaMicroservicios.Libro.Presentation.UpdateLibroResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateLibro",
        __Marshaller_UpdateLibroRequest,
        __Marshaller_UpdateLibroResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::PruebaMicroservicios.Libro.Presentation.DeleteLibroRequest, global::PruebaMicroservicios.Libro.Presentation.DeleteLibroResponse> __Method_DeleteLibro = new grpc::Method<global::PruebaMicroservicios.Libro.Presentation.DeleteLibroRequest, global::PruebaMicroservicios.Libro.Presentation.DeleteLibroResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteLibro",
        __Marshaller_DeleteLibroRequest,
        __Marshaller_DeleteLibroResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::PruebaMicroservicios.Libro.Presentation.LibroReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Libro</summary>
    [grpc::BindServiceMethod(typeof(Libro), "BindService")]
    public abstract partial class LibroBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::PruebaMicroservicios.Libro.Presentation.GetLibroByIdResponse> GetLibro(global::PruebaMicroservicios.Libro.Presentation.GetLibroByIdRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::PruebaMicroservicios.Libro.Presentation.GetAllLibroResponse> GetAllLibro(global::PruebaMicroservicios.Libro.Presentation.GetAllLibroRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::PruebaMicroservicios.Libro.Presentation.GetAllLibroByAutorResponse> GetAllLibroByAutor(global::PruebaMicroservicios.Libro.Presentation.GetAllLibroByAutorRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::PruebaMicroservicios.Libro.Presentation.CreateLibroResponse> CreateLibro(global::PruebaMicroservicios.Libro.Presentation.CreateLibroRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::PruebaMicroservicios.Libro.Presentation.UpdateLibroResponse> UpdateLibro(global::PruebaMicroservicios.Libro.Presentation.UpdateLibroRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::PruebaMicroservicios.Libro.Presentation.DeleteLibroResponse> DeleteLibro(global::PruebaMicroservicios.Libro.Presentation.DeleteLibroRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(LibroBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetLibro, serviceImpl.GetLibro)
          .AddMethod(__Method_GetAllLibro, serviceImpl.GetAllLibro)
          .AddMethod(__Method_GetAllLibroByAutor, serviceImpl.GetAllLibroByAutor)
          .AddMethod(__Method_CreateLibro, serviceImpl.CreateLibro)
          .AddMethod(__Method_UpdateLibro, serviceImpl.UpdateLibro)
          .AddMethod(__Method_DeleteLibro, serviceImpl.DeleteLibro).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, LibroBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetLibro, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PruebaMicroservicios.Libro.Presentation.GetLibroByIdRequest, global::PruebaMicroservicios.Libro.Presentation.GetLibroByIdResponse>(serviceImpl.GetLibro));
      serviceBinder.AddMethod(__Method_GetAllLibro, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PruebaMicroservicios.Libro.Presentation.GetAllLibroRequest, global::PruebaMicroservicios.Libro.Presentation.GetAllLibroResponse>(serviceImpl.GetAllLibro));
      serviceBinder.AddMethod(__Method_GetAllLibroByAutor, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PruebaMicroservicios.Libro.Presentation.GetAllLibroByAutorRequest, global::PruebaMicroservicios.Libro.Presentation.GetAllLibroByAutorResponse>(serviceImpl.GetAllLibroByAutor));
      serviceBinder.AddMethod(__Method_CreateLibro, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PruebaMicroservicios.Libro.Presentation.CreateLibroRequest, global::PruebaMicroservicios.Libro.Presentation.CreateLibroResponse>(serviceImpl.CreateLibro));
      serviceBinder.AddMethod(__Method_UpdateLibro, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PruebaMicroservicios.Libro.Presentation.UpdateLibroRequest, global::PruebaMicroservicios.Libro.Presentation.UpdateLibroResponse>(serviceImpl.UpdateLibro));
      serviceBinder.AddMethod(__Method_DeleteLibro, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PruebaMicroservicios.Libro.Presentation.DeleteLibroRequest, global::PruebaMicroservicios.Libro.Presentation.DeleteLibroResponse>(serviceImpl.DeleteLibro));
    }

  }
}
#endregion
