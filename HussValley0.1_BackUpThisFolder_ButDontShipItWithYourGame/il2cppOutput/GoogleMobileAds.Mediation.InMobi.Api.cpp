#include "pch-cpp.hpp"





template <typename T1>
struct InterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};

struct Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83;
struct IEqualityComparer_1_tAE94C8F24AD5B94D4EE85CA9FC59E3409D41CAF7;
struct KeyCollection_t2EDD317F5771E575ACB63527B5AFB71291040342;
struct ValueCollection_t238D0D2427C6B841A01F522A41540165A2C4AE76;
struct EntryU5BU5D_t1AF33AD0B7330843448956EC4277517081658AE7;
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
struct IInMobiClient_t176FADCFF704F9D5387E002E514DD8898C4F0B9B;
struct InMobi_t250A2B0FC5FF8B94772403F845A1AD6DD8276ADC;
struct InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943;
struct String_t;
struct UnitySourceGeneratedAssemblyMonoScriptTypes_v1_tB8F4DDAE234DFA69D48E77BABF6405ACB34AF632;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;

IL2CPP_EXTERN_C RuntimeClass* ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IInMobiClient_t176FADCFF704F9D5387E002E514DD8898C4F0B9B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeField* U3CPrivateImplementationDetailsU3E_t48A912E02D22D770499B3476314284DC42EA599F____7314530DBE1D21743D57E8410F91FCC409C8CFF24A98789A84B1FE92EBD7A881_FieldInfo_var;
IL2CPP_EXTERN_C RuntimeField* U3CPrivateImplementationDetailsU3E_t48A912E02D22D770499B3476314284DC42EA599F____A807D5D66921E190ACB7013144E1DCDD15C8FF2E8AE013F1EEA52C57995E59A0_FieldInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral393E29D09C71D9FB4F9D9E1F4C1C5039F535F149;

struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct U3CModuleU3E_t9B1E4AA50A83FC5AE77BE190DC01E9D454584EC2 
{
};
struct Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83  : public RuntimeObject
{
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ____buckets;
	EntryU5BU5D_t1AF33AD0B7330843448956EC4277517081658AE7* ____entries;
	int32_t ____count;
	int32_t ____freeList;
	int32_t ____freeCount;
	int32_t ____version;
	RuntimeObject* ____comparer;
	KeyCollection_t2EDD317F5771E575ACB63527B5AFB71291040342* ____keys;
	ValueCollection_t238D0D2427C6B841A01F522A41540165A2C4AE76* ____values;
	RuntimeObject* ____syncRoot;
};
struct U3CPrivateImplementationDetailsU3E_t48A912E02D22D770499B3476314284DC42EA599F  : public RuntimeObject
{
};
struct InMobi_t250A2B0FC5FF8B94772403F845A1AD6DD8276ADC  : public RuntimeObject
{
};
struct InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943  : public RuntimeObject
{
};
struct String_t  : public RuntimeObject
{
	int32_t ____stringLength;
	Il2CppChar ____firstChar;
};
struct UnitySourceGeneratedAssemblyMonoScriptTypes_v1_tB8F4DDAE234DFA69D48E77BABF6405ACB34AF632  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value;
};
struct Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3 
{
	uint8_t ___m_value;
};
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	int32_t ___m_value;
};
struct IntPtr_t 
{
	void* ___m_value;
};
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
#pragma pack(push, tp, 1)
struct __StaticArrayInitTypeSizeU3D62_t15DBA954D281337F7645948E8F2971FDC7DFD5DD 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D62_t15DBA954D281337F7645948E8F2971FDC7DFD5DD__padding[62];
	};
};
#pragma pack(pop, tp)
#pragma pack(push, tp, 1)
struct __StaticArrayInitTypeSizeU3D96_tA2F7EC2C67AF3B0E390CA280E0AAF9AA5974180E 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D96_tA2F7EC2C67AF3B0E390CA280E0AAF9AA5974180E__padding[96];
	};
};
#pragma pack(pop, tp)
struct MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128 
{
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___FilePathsData;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___TypesData;
	int32_t ___TotalTypes;
	int32_t ___TotalFiles;
	bool ___IsEditorOnly;
};
struct MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128_marshaled_pinvoke
{
	Il2CppSafeArray* ___FilePathsData;
	Il2CppSafeArray* ___TypesData;
	int32_t ___TotalTypes;
	int32_t ___TotalFiles;
	int32_t ___IsEditorOnly;
};
struct MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128_marshaled_com
{
	Il2CppSafeArray* ___FilePathsData;
	Il2CppSafeArray* ___TypesData;
	int32_t ___TotalTypes;
	int32_t ___TotalFiles;
	int32_t ___IsEditorOnly;
};
struct RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 
{
	intptr_t ___value;
};
struct U3CPrivateImplementationDetailsU3E_t48A912E02D22D770499B3476314284DC42EA599F_StaticFields
{
	__StaticArrayInitTypeSizeU3D96_tA2F7EC2C67AF3B0E390CA280E0AAF9AA5974180E ___7314530DBE1D21743D57E8410F91FCC409C8CFF24A98789A84B1FE92EBD7A881;
	__StaticArrayInitTypeSizeU3D62_t15DBA954D281337F7645948E8F2971FDC7DFD5DD ___A807D5D66921E190ACB7013144E1DCDD15C8FF2E8AE013F1EEA52C57995E59A0;
};
struct InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943_StaticFields
{
	RuntimeObject* ___client;
};
struct String_t_StaticFields
{
	String_t* ___Empty;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString;
	String_t* ___FalseString;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031  : public RuntimeArray
{
	ALIGN_FIELD (8) uint8_t m_Items[1];

	inline uint8_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint8_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint8_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint8_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint8_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint8_t value)
	{
		m_Items[index] = value;
	}
};



IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B (RuntimeArray* ___0_array, RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 ___1_fldHandle, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InMobi_UpdateGDPRConsent_m915C5EBEDE6583BEDE9E8BF1BB83913B7B4E8A85 (Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___0_consentObject, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MonoBehaviour_print_m9E6FF71C673B651F35DD418C293CFC50C46803B6 (RuntimeObject* ___0_message, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* InMobiClientFactory_InMobiInstance_m1062C583D0C10DD2CA95D55EAFF353B1787365F3 (const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 74446
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128 UnitySourceGeneratedAssemblyMonoScriptTypes_v1_Get_m74F9FB7F1536936324B37B0E564BC3B5C136E706 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CPrivateImplementationDetailsU3E_t48A912E02D22D770499B3476314284DC42EA599F____7314530DBE1D21743D57E8410F91FCC409C8CFF24A98789A84B1FE92EBD7A881_FieldInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CPrivateImplementationDetailsU3E_t48A912E02D22D770499B3476314284DC42EA599F____A807D5D66921E190ACB7013144E1DCDD15C8FF2E8AE013F1EEA52C57995E59A0_FieldInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		il2cpp_codegen_initobj((&V_0), sizeof(MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)((int32_t)62));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = L_0;
		RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 L_2 = { reinterpret_cast<intptr_t> (U3CPrivateImplementationDetailsU3E_t48A912E02D22D770499B3476314284DC42EA599F____A807D5D66921E190ACB7013144E1DCDD15C8FF2E8AE013F1EEA52C57995E59A0_FieldInfo_var) };
		RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B((RuntimeArray*)L_1, L_2, NULL);
		(&V_0)->___FilePathsData = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&(&V_0)->___FilePathsData), (void*)L_1);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)((int32_t)96));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = L_3;
		RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 L_5 = { reinterpret_cast<intptr_t> (U3CPrivateImplementationDetailsU3E_t48A912E02D22D770499B3476314284DC42EA599F____7314530DBE1D21743D57E8410F91FCC409C8CFF24A98789A84B1FE92EBD7A881_FieldInfo_var) };
		RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B((RuntimeArray*)L_4, L_5, NULL);
		(&V_0)->___TypesData = L_4;
		Il2CppCodeGenWriteBarrier((void**)(&(&V_0)->___TypesData), (void*)L_4);
		(&V_0)->___TotalFiles = 1;
		(&V_0)->___TotalTypes = 2;
		(&V_0)->___IsEditorOnly = (bool)0;
		MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128 L_6 = V_0;
		return L_6;
	}
}
// Method Definition Index: 74447
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnitySourceGeneratedAssemblyMonoScriptTypes_v1__ctor_m6773CF7F38E359D4119881DC8B4F6B6EF8C8309A (UnitySourceGeneratedAssemblyMonoScriptTypes_v1_tB8F4DDAE234DFA69D48E77BABF6405ACB34AF632* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C void MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128_marshal_pinvoke(const MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128& unmarshaled, MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128_marshaled_pinvoke& marshaled)
{
	marshaled.___FilePathsData = il2cpp_codegen_com_marshal_safe_array(IL2CPP_VT_I1, unmarshaled.___FilePathsData);
	marshaled.___TypesData = il2cpp_codegen_com_marshal_safe_array(IL2CPP_VT_I1, unmarshaled.___TypesData);
	marshaled.___TotalTypes = unmarshaled.___TotalTypes;
	marshaled.___TotalFiles = unmarshaled.___TotalFiles;
	marshaled.___IsEditorOnly = static_cast<int32_t>(unmarshaled.___IsEditorOnly);
}
IL2CPP_EXTERN_C void MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128_marshal_pinvoke_back(const MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128_marshaled_pinvoke& marshaled, MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128& unmarshaled)
{
	unmarshaled.___FilePathsData = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, il2cpp_defaults.byte_class, marshaled.___FilePathsData);
	Il2CppCodeGenWriteBarrier((void**)(&unmarshaled.___FilePathsData), (void*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, il2cpp_defaults.byte_class, marshaled.___FilePathsData));
	unmarshaled.___TypesData = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, il2cpp_defaults.byte_class, marshaled.___TypesData);
	Il2CppCodeGenWriteBarrier((void**)(&unmarshaled.___TypesData), (void*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, il2cpp_defaults.byte_class, marshaled.___TypesData));
	int32_t unmarshaledTotalTypes_temp_2 = 0;
	unmarshaledTotalTypes_temp_2 = marshaled.___TotalTypes;
	unmarshaled.___TotalTypes = unmarshaledTotalTypes_temp_2;
	int32_t unmarshaledTotalFiles_temp_3 = 0;
	unmarshaledTotalFiles_temp_3 = marshaled.___TotalFiles;
	unmarshaled.___TotalFiles = unmarshaledTotalFiles_temp_3;
	bool unmarshaledIsEditorOnly_temp_4 = false;
	unmarshaledIsEditorOnly_temp_4 = static_cast<bool>(marshaled.___IsEditorOnly);
	unmarshaled.___IsEditorOnly = unmarshaledIsEditorOnly_temp_4;
}
IL2CPP_EXTERN_C void MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128_marshal_pinvoke_cleanup(MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128_marshaled_pinvoke& marshaled)
{
	il2cpp_codegen_com_destroy_safe_array(marshaled.___FilePathsData);
	marshaled.___FilePathsData = NULL;
	il2cpp_codegen_com_destroy_safe_array(marshaled.___TypesData);
	marshaled.___TypesData = NULL;
}
IL2CPP_EXTERN_C void MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128_marshal_com(const MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128& unmarshaled, MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128_marshaled_com& marshaled)
{
	marshaled.___FilePathsData = il2cpp_codegen_com_marshal_safe_array(IL2CPP_VT_I1, unmarshaled.___FilePathsData);
	marshaled.___TypesData = il2cpp_codegen_com_marshal_safe_array(IL2CPP_VT_I1, unmarshaled.___TypesData);
	marshaled.___TotalTypes = unmarshaled.___TotalTypes;
	marshaled.___TotalFiles = unmarshaled.___TotalFiles;
	marshaled.___IsEditorOnly = static_cast<int32_t>(unmarshaled.___IsEditorOnly);
}
IL2CPP_EXTERN_C void MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128_marshal_com_back(const MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128_marshaled_com& marshaled, MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128& unmarshaled)
{
	unmarshaled.___FilePathsData = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, il2cpp_defaults.byte_class, marshaled.___FilePathsData);
	Il2CppCodeGenWriteBarrier((void**)(&unmarshaled.___FilePathsData), (void*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, il2cpp_defaults.byte_class, marshaled.___FilePathsData));
	unmarshaled.___TypesData = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, il2cpp_defaults.byte_class, marshaled.___TypesData);
	Il2CppCodeGenWriteBarrier((void**)(&unmarshaled.___TypesData), (void*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)il2cpp_codegen_com_marshal_safe_array_result(IL2CPP_VT_I1, il2cpp_defaults.byte_class, marshaled.___TypesData));
	int32_t unmarshaledTotalTypes_temp_2 = 0;
	unmarshaledTotalTypes_temp_2 = marshaled.___TotalTypes;
	unmarshaled.___TotalTypes = unmarshaledTotalTypes_temp_2;
	int32_t unmarshaledTotalFiles_temp_3 = 0;
	unmarshaledTotalFiles_temp_3 = marshaled.___TotalFiles;
	unmarshaled.___TotalFiles = unmarshaledTotalFiles_temp_3;
	bool unmarshaledIsEditorOnly_temp_4 = false;
	unmarshaledIsEditorOnly_temp_4 = static_cast<bool>(marshaled.___IsEditorOnly);
	unmarshaled.___IsEditorOnly = unmarshaledIsEditorOnly_temp_4;
}
IL2CPP_EXTERN_C void MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128_marshal_com_cleanup(MonoScriptData_tB5DB1B4F48B91FF5427DBC23BF1CF26EE2D41128_marshaled_com& marshaled)
{
	il2cpp_codegen_com_destroy_safe_array(marshaled.___FilePathsData);
	marshaled.___FilePathsData = NULL;
	il2cpp_codegen_com_destroy_safe_array(marshaled.___TypesData);
	marshaled.___TypesData = NULL;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 74448
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InMobi_UpdateGDPRConsent_m4CFEEA89A5ADD64EA5530B421624E898B6655B86 (Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___0_consentObject, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/InMobi/Api/InMobi.cs:46>
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_0 = ___0_consentObject;
		il2cpp_codegen_runtime_class_init_inline(InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943_il2cpp_TypeInfo_var);
		InMobi_UpdateGDPRConsent_m915C5EBEDE6583BEDE9E8BF1BB83913B7B4E8A85(L_0, NULL);
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/InMobi/Api/InMobi.cs:47>
		return;
	}
}
// Method Definition Index: 74449
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InMobi__ctor_m885672C6CC503B1A9CBD4142CB77F4730CB9FDCC (InMobi_t250A2B0FC5FF8B94772403F845A1AD6DD8276ADC* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Method Definition Index: 74450
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InMobi_UpdateGDPRConsent_m915C5EBEDE6583BEDE9E8BF1BB83913B7B4E8A85 (Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___0_consentObject, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IInMobiClient_t176FADCFF704F9D5387E002E514DD8898C4F0B9B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral393E29D09C71D9FB4F9D9E1F4C1C5039F535F149);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/InMobi/Api/InMobi.cs:28>
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_0 = ___0_consentObject;
		if (L_0)
		{
			goto IL_000e;
		}
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/InMobi/Api/InMobi.cs:30>
		MonoBehaviour_print_m9E6FF71C673B651F35DD418C293CFC50C46803B6(_stringLiteral393E29D09C71D9FB4F9D9E1F4C1C5039F535F149, NULL);
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/InMobi/Api/InMobi.cs:31>
		return;
	}

IL_000e:
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/InMobi/Api/InMobi.cs:34>
		il2cpp_codegen_runtime_class_init_inline(InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943_il2cpp_TypeInfo_var);
		RuntimeObject* L_1 = ((InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943_StaticFields*)il2cpp_codegen_static_fields_for(InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943_il2cpp_TypeInfo_var))->___client;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_2 = ___0_consentObject;
		NullCheck(L_1);
		InterfaceActionInvoker1< Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* >::Invoke(0, IInMobiClient_t176FADCFF704F9D5387E002E514DD8898C4F0B9B_il2cpp_TypeInfo_var, L_1, L_2);
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/InMobi/Api/InMobi.cs:35>
		return;
	}
}
// Method Definition Index: 74451
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InMobi__ctor_m43D718F92418879BE5C6BA228825BFE0929180D2 (InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
// Method Definition Index: 74452
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InMobi__cctor_m4A23ACFFFC34214191CCBE3023733DFD44CA984C (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/InMobi/Api/InMobi.cs:24>
		RuntimeObject* L_0;
		L_0 = InMobiClientFactory_InMobiInstance_m1062C583D0C10DD2CA95D55EAFF353B1787365F3(NULL);
		((InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943_StaticFields*)il2cpp_codegen_static_fields_for(InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943_il2cpp_TypeInfo_var))->___client = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943_StaticFields*)il2cpp_codegen_static_fields_for(InMobi_tBF816D49390D6D90DFC1AFD58BCD0F1A3EA6A943_il2cpp_TypeInfo_var))->___client), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
