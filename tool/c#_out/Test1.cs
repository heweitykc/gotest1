// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: test1.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Example {

  /// <summary>Holder for reflection information generated from test1.proto</summary>
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public static partial class Test1Reflection {

    #region Descriptor
    /// <summary>File descriptor for test1.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static Test1Reflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cgt0ZXN0MS5wcm90bxIHZXhhbXBsZSIxCgRUZXN0Eg0KBWxhYmVsGAEgASgJ",
            "EgwKBHR5cGUYAiABKAUSDAoEcmVwcxgDIAMoAyoMCgNGT08SBQoBWBAAYgZw",
            "cm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Example.FOO), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Example.Test), global::Example.Test.Parser, new[]{ "Label", "Type", "Reps" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum FOO {
    [pbr::OriginalName("X")] X = 0,
  }

  #endregion

  #region Messages
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public sealed partial class Test : pb::IMessage<Test> {
    private static readonly pb::MessageParser<Test> _parser = new pb::MessageParser<Test>(() => new Test());
    public static pb::MessageParser<Test> Parser { get { return _parser; } }

    public static pbr::MessageDescriptor Descriptor {
      get { return global::Example.Test1Reflection.Descriptor.MessageTypes[0]; }
    }

    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    public Test() {
      OnConstruction();
    }

    partial void OnConstruction();

    public Test(Test other) : this() {
      label_ = other.label_;
      type_ = other.type_;
      reps_ = other.reps_.Clone();
    }

    public Test Clone() {
      return new Test(this);
    }

    /// <summary>Field number for the "label" field.</summary>
    public const int LabelFieldNumber = 1;
    private string label_ = "";
    public string Label {
      get { return label_; }
      set {
        label_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "type" field.</summary>
    public const int TypeFieldNumber = 2;
    private int type_;
    public int Type {
      get { return type_; }
      set {
        type_ = value;
      }
    }

    /// <summary>Field number for the "reps" field.</summary>
    public const int RepsFieldNumber = 3;
    private static readonly pb::FieldCodec<long> _repeated_reps_codec
        = pb::FieldCodec.ForInt64(26);
    private readonly pbc::RepeatedField<long> reps_ = new pbc::RepeatedField<long>();
    public pbc::RepeatedField<long> Reps {
      get { return reps_; }
    }

    public override bool Equals(object other) {
      return Equals(other as Test);
    }

    public bool Equals(Test other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Label != other.Label) return false;
      if (Type != other.Type) return false;
      if(!reps_.Equals(other.reps_)) return false;
      return true;
    }

    public override int GetHashCode() {
      int hash = 1;
      if (Label.Length != 0) hash ^= Label.GetHashCode();
      if (Type != 0) hash ^= Type.GetHashCode();
      hash ^= reps_.GetHashCode();
      return hash;
    }

    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    public void WriteTo(pb::CodedOutputStream output) {
      if (Label.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Label);
      }
      if (Type != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Type);
      }
      reps_.WriteTo(output, _repeated_reps_codec);
    }

    public int CalculateSize() {
      int size = 0;
      if (Label.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Label);
      }
      if (Type != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Type);
      }
      size += reps_.CalculateSize(_repeated_reps_codec);
      return size;
    }

    public void MergeFrom(Test other) {
      if (other == null) {
        return;
      }
      if (other.Label.Length != 0) {
        Label = other.Label;
      }
      if (other.Type != 0) {
        Type = other.Type;
      }
      reps_.Add(other.reps_);
    }

    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Label = input.ReadString();
            break;
          }
          case 16: {
            Type = input.ReadInt32();
            break;
          }
          case 26:
          case 24: {
            reps_.AddEntriesFrom(input, _repeated_reps_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code