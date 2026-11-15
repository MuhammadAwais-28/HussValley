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
template <typename T1, typename T2>
struct InterfaceActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};

struct Dictionary_2_t14FE4A752A83D53771C584E4C8D14E01F2AFD7BA;
struct Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83;
struct IEqualityComparer_1_tAE94C8F24AD5B94D4EE85CA9FC59E3409D41CAF7;
struct KeyCollection_t2EDD317F5771E575ACB63527B5AFB71291040342;
struct ValueCollection_t238D0D2427C6B841A01F522A41540165A2C4AE76;
struct EntryU5BU5D_t1AF33AD0B7330843448956EC4277517081658AE7;
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
struct ILiftoffMonetizeClient_t8B2099DE4AB5A1E762A85E009E1024054A35F10B;
struct LiftoffMonetize_tE8B0F3247AD509D93568669B96C4AC1A5065285E;
struct LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5;
struct LiftoffMonetizeInterstitialMediationExtras_tF1D3D2AF3B66A654903706934AC4C791AFA95E28;
struct LiftoffMonetizeInterstitialMediationExtras_t9ABCFD32DEB64D9CA1238EE969D02A3D876FA0FA;
struct LiftoffMonetizeMediationExtras_tF6365E3164E85196EB6F5A5F50CEFFC3288C454F;
struct LiftoffMonetizeMediationExtras_tE9A01B8891754AE6A27A8D5A80C88D15683FB92F;
struct LiftoffMonetizeRewardedVideoMediationExtras_t6085DD51055F91CE733F11A69F60C506D8CC982D;
struct LiftoffMonetizeRewardedVideoMediationExtras_t14877777D71BEBE87927B9906491B401067EB1F3;
struct MediationExtras_t390586958F7ED4B158AD5AD18F58A86E9E7B621E;
struct String_t;
struct UnitySourceGeneratedAssemblyMonoScriptTypes_v1_t5D1F26863D9FD0DE096CA13EA8BC4EF22E48B831;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;

IL2CPP_EXTERN_C RuntimeClass* ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ILiftoffMonetizeClient_t8B2099DE4AB5A1E762A85E009E1024054A35F10B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeField* U3CPrivateImplementationDetailsU3E_tCB8B52D8F1EB764694818D9E15F67A99DC3F601C____B3F2F173B37095FBAB9D1AD0026F74AD1C65551D36470CAF1093B8B3058B6CA7_FieldInfo_var;
IL2CPP_EXTERN_C RuntimeField* U3CPrivateImplementationDetailsU3E_tCB8B52D8F1EB764694818D9E15F67A99DC3F601C____FB7F3F544124C0657AD48017334BDBF790BEFD4111B3BD27CB60B9C387C59131_FieldInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral04CB9283C54164437AE23405A80C594A6B5EC5F3;
IL2CPP_EXTERN_C String_t* _stringLiteral1569FBCE1AEF76BAED4D9AA69B332587D68D1AE3;
IL2CPP_EXTERN_C String_t* _stringLiteral18C9119C90B722EAA1F9CDB9148C197333078575;
IL2CPP_EXTERN_C String_t* _stringLiteral5867241742D6306548A7EB604F5B2D241B3CD423;
IL2CPP_EXTERN_C String_t* _stringLiteral9AD9278DAE04CE0651B8FC80CE2517B992EEFF36;
IL2CPP_EXTERN_C String_t* _stringLiteralA7B2B81C30399980CEC0EBDD4721BDAE3A1A2DFD;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2_Add_mC78C20D5901C87AAC38F37C906FAB6946BDE5F13_RuntimeMethod_var;

struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct U3CModuleU3E_t38A8BF7518599663CB56A0191AB791B49DF3E126 
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
struct U3CPrivateImplementationDetailsU3E_tCB8B52D8F1EB764694818D9E15F67A99DC3F601C  : public RuntimeObject
{
};
struct LiftoffMonetize_tE8B0F3247AD509D93568669B96C4AC1A5065285E  : public RuntimeObject
{
};
struct LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5  : public RuntimeObject
{
};
struct MediationExtras_t390586958F7ED4B158AD5AD18F58A86E9E7B621E  : public RuntimeObject
{
	Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___U3CExtrasU3Ek__BackingField;
};
struct String_t  : public RuntimeObject
{
	int32_t ____stringLength;
	Il2CppChar ____firstChar;
};
struct UnitySourceGeneratedAssemblyMonoScriptTypes_v1_t5D1F26863D9FD0DE096CA13EA8BC4EF22E48B831  : public RuntimeObject
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
struct LiftoffMonetizeMediationExtras_tE9A01B8891754AE6A27A8D5A80C88D15683FB92F  : public MediationExtras_t390586958F7ED4B158AD5AD18F58A86E9E7B621E
{
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
struct __StaticArrayInitTypeSizeU3D390_t3079549E7C5DA9F6C63355F2FA0B932AB193AFAE 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D390_t3079549E7C5DA9F6C63355F2FA0B932AB193AFAE__padding[390];
	};
};
#pragma pack(pop, tp)
#pragma pack(push, tp, 1)
struct __StaticArrayInitTypeSizeU3D668_tB8B011C50F6E1B756EB6527909D6037CE0BE0BAA 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D668_tB8B011C50F6E1B756EB6527909D6037CE0BE0BAA__padding[668];
	};
};
#pragma pack(pop, tp)
struct MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608 
{
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___FilePathsData;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___TypesData;
	int32_t ___TotalTypes;
	int32_t ___TotalFiles;
	bool ___IsEditorOnly;
};
struct MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608_marshaled_pinvoke
{
	Il2CppSafeArray* ___FilePathsData;
	Il2CppSafeArray* ___TypesData;
	int32_t ___TotalTypes;
	int32_t ___TotalFiles;
	int32_t ___IsEditorOnly;
};
struct MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608_marshaled_com
{
	Il2CppSafeArray* ___FilePathsData;
	Il2CppSafeArray* ___TypesData;
	int32_t ___TotalTypes;
	int32_t ___TotalFiles;
	int32_t ___IsEditorOnly;
};
struct LiftoffMonetizeInterstitialMediationExtras_t9ABCFD32DEB64D9CA1238EE969D02A3D876FA0FA  : public LiftoffMonetizeMediationExtras_tE9A01B8891754AE6A27A8D5A80C88D15683FB92F
{
};
struct LiftoffMonetizeMediationExtras_tF6365E3164E85196EB6F5A5F50CEFFC3288C454F  : public LiftoffMonetizeMediationExtras_tE9A01B8891754AE6A27A8D5A80C88D15683FB92F
{
};
struct LiftoffMonetizeRewardedVideoMediationExtras_t14877777D71BEBE87927B9906491B401067EB1F3  : public LiftoffMonetizeMediationExtras_tE9A01B8891754AE6A27A8D5A80C88D15683FB92F
{
};
struct RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 
{
	intptr_t ___value;
};
struct LiftoffMonetizeInterstitialMediationExtras_tF1D3D2AF3B66A654903706934AC4C791AFA95E28  : public LiftoffMonetizeInterstitialMediationExtras_t9ABCFD32DEB64D9CA1238EE969D02A3D876FA0FA
{
};
struct LiftoffMonetizeRewardedVideoMediationExtras_t6085DD51055F91CE733F11A69F60C506D8CC982D  : public LiftoffMonetizeRewardedVideoMediationExtras_t14877777D71BEBE87927B9906491B401067EB1F3
{
};
struct U3CPrivateImplementationDetailsU3E_tCB8B52D8F1EB764694818D9E15F67A99DC3F601C_StaticFields
{
	__StaticArrayInitTypeSizeU3D668_tB8B011C50F6E1B756EB6527909D6037CE0BE0BAA ___B3F2F173B37095FBAB9D1AD0026F74AD1C65551D36470CAF1093B8B3058B6CA7;
	__StaticArrayInitTypeSizeU3D390_t3079549E7C5DA9F6C63355F2FA0B932AB193AFAE ___FB7F3F544124C0657AD48017334BDBF790BEFD4111B3BD27CB60B9C387C59131;
};
struct LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_StaticFields
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


IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Dictionary_2_Add_m93FFFABE8FCE7FA9793F0915E2A8842C7CD0C0C1_gshared (Dictionary_2_t14FE4A752A83D53771C584E4C8D14E01F2AFD7BA* __this, RuntimeObject* ___0_key, RuntimeObject* ___1_value, const RuntimeMethod* method) ;

IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B (RuntimeArray* ___0_array, RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 ___1_fldHandle, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetize_SetGDPRStatus_m80775529622818861919633EC0CCB27F20D63D9B (bool ___0_gdprStatus, String_t* ___1_consentMessageVersion, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetize_SetGDPRMessageVersion_m07F8F8B135893F7CB5E5A30757322AFA28A0F5D0 (String_t* ___0_gdprMessageVersion, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetize_SetCCPAStatus_m169F04B7539538674F30E8B34B6658267506F302 (bool ___0_ccpaStatus, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetizeInterstitialMediationExtras__ctor_m205AF65B48FB9B719A466D6FC33A967C6342ECC4 (LiftoffMonetizeInterstitialMediationExtras_t9ABCFD32DEB64D9CA1238EE969D02A3D876FA0FA* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetizeMediationExtras__ctor_m42B2D834AD632125DE97F8ADEF58D411E2E4CFA8 (LiftoffMonetizeMediationExtras_tE9A01B8891754AE6A27A8D5A80C88D15683FB92F* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetizeRewardedVideoMediationExtras__ctor_m1FAE6FB4B09FF21504C732BF7799F1FDB0FB6BC4 (LiftoffMonetizeRewardedVideoMediationExtras_t14877777D71BEBE87927B9906491B401067EB1F3* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* LiftoffMonetizeClientFactory_CreateLiftoffMonetizeClient_m9605F7CF8B6D6E53D4DF1627397E0B2CCCCF8E96 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MediationExtras__ctor_mEFD02928F64CB007F296DC0B00BECCDC39F3869B (MediationExtras_t390586958F7ED4B158AD5AD18F58A86E9E7B621E* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* MediationExtras_get_Extras_m301316E0049B5580869A85F9414C82445BADEB81_inline (MediationExtras_t390586958F7ED4B158AD5AD18F58A86E9E7B621E* __this, const RuntimeMethod* method) ;
inline void Dictionary_2_Add_mC78C20D5901C87AAC38F37C906FAB6946BDE5F13 (Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* __this, String_t* ___0_key, String_t* ___1_value, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83*, String_t*, String_t*, const RuntimeMethod*))Dictionary_2_Add_m93FFFABE8FCE7FA9793F0915E2A8842C7CD0C0C1_gshared)(__this, ___0_key, ___1_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Boolean_ToString_m6646C8026B1DF381A1EE8CD13549175E9703CC63 (bool* __this, const RuntimeMethod* method) ;
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
// Method Definition Index: 74353
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608 UnitySourceGeneratedAssemblyMonoScriptTypes_v1_Get_m4E2ACF63CDFFFA6C78FF273EBD9BAAEC78F0F052 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CPrivateImplementationDetailsU3E_tCB8B52D8F1EB764694818D9E15F67A99DC3F601C____B3F2F173B37095FBAB9D1AD0026F74AD1C65551D36470CAF1093B8B3058B6CA7_FieldInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CPrivateImplementationDetailsU3E_tCB8B52D8F1EB764694818D9E15F67A99DC3F601C____FB7F3F544124C0657AD48017334BDBF790BEFD4111B3BD27CB60B9C387C59131_FieldInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		il2cpp_codegen_initobj((&V_0), sizeof(MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)((int32_t)390));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = L_0;
		RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 L_2 = { reinterpret_cast<intptr_t> (U3CPrivateImplementationDetailsU3E_tCB8B52D8F1EB764694818D9E15F67A99DC3F601C____FB7F3F544124C0657AD48017334BDBF790BEFD4111B3BD27CB60B9C387C59131_FieldInfo_var) };
		RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B((RuntimeArray*)L_1, L_2, NULL);
		(&V_0)->___FilePathsData = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&(&V_0)->___FilePathsData), (void*)L_1);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)((int32_t)668));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = L_3;
		RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 L_5 = { reinterpret_cast<intptr_t> (U3CPrivateImplementationDetailsU3E_tCB8B52D8F1EB764694818D9E15F67A99DC3F601C____B3F2F173B37095FBAB9D1AD0026F74AD1C65551D36470CAF1093B8B3058B6CA7_FieldInfo_var) };
		RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B((RuntimeArray*)L_4, L_5, NULL);
		(&V_0)->___TypesData = L_4;
		Il2CppCodeGenWriteBarrier((void**)(&(&V_0)->___TypesData), (void*)L_4);
		(&V_0)->___TotalFiles = 4;
		(&V_0)->___TotalTypes = 8;
		(&V_0)->___IsEditorOnly = (bool)0;
		MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608 L_6 = V_0;
		return L_6;
	}
}
// Method Definition Index: 74354
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnitySourceGeneratedAssemblyMonoScriptTypes_v1__ctor_m42646EF0064FC44CF4336E85A6F3F3A2EEB6B097 (UnitySourceGeneratedAssemblyMonoScriptTypes_v1_t5D1F26863D9FD0DE096CA13EA8BC4EF22E48B831* __this, const RuntimeMethod* method) 
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
IL2CPP_EXTERN_C void MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608_marshal_pinvoke(const MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608& unmarshaled, MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608_marshaled_pinvoke& marshaled)
{
	marshaled.___FilePathsData = il2cpp_codegen_com_marshal_safe_array(IL2CPP_VT_I1, unmarshaled.___FilePathsData);
	marshaled.___TypesData = il2cpp_codegen_com_marshal_safe_array(IL2CPP_VT_I1, unmarshaled.___TypesData);
	marshaled.___TotalTypes = unmarshaled.___TotalTypes;
	marshaled.___TotalFiles = unmarshaled.___TotalFiles;
	marshaled.___IsEditorOnly = static_cast<int32_t>(unmarshaled.___IsEditorOnly);
}
IL2CPP_EXTERN_C void MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608_marshal_pinvoke_back(const MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608_marshaled_pinvoke& marshaled, MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608& unmarshaled)
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
IL2CPP_EXTERN_C void MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608_marshal_pinvoke_cleanup(MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608_marshaled_pinvoke& marshaled)
{
	il2cpp_codegen_com_destroy_safe_array(marshaled.___FilePathsData);
	marshaled.___FilePathsData = NULL;
	il2cpp_codegen_com_destroy_safe_array(marshaled.___TypesData);
	marshaled.___TypesData = NULL;
}
IL2CPP_EXTERN_C void MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608_marshal_com(const MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608& unmarshaled, MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608_marshaled_com& marshaled)
{
	marshaled.___FilePathsData = il2cpp_codegen_com_marshal_safe_array(IL2CPP_VT_I1, unmarshaled.___FilePathsData);
	marshaled.___TypesData = il2cpp_codegen_com_marshal_safe_array(IL2CPP_VT_I1, unmarshaled.___TypesData);
	marshaled.___TotalTypes = unmarshaled.___TotalTypes;
	marshaled.___TotalFiles = unmarshaled.___TotalFiles;
	marshaled.___IsEditorOnly = static_cast<int32_t>(unmarshaled.___IsEditorOnly);
}
IL2CPP_EXTERN_C void MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608_marshal_com_back(const MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608_marshaled_com& marshaled, MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608& unmarshaled)
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
IL2CPP_EXTERN_C void MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608_marshal_com_cleanup(MonoScriptData_tD8367ED7F2CD4D3C35BF03E1A735255477530608_marshaled_com& marshaled)
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
// Method Definition Index: 74355
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetize_SetGDPRStatus_m4183587C66CAB828371DF08A6EADE33E0DAC0C17 (bool ___0_gdprStatus, String_t* ___1_consentMessageVersion, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:50>
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:51>
		bool L_0 = ___0_gdprStatus;
		String_t* L_1 = ___1_consentMessageVersion;
		il2cpp_codegen_runtime_class_init_inline(LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var);
		LiftoffMonetize_SetGDPRStatus_m80775529622818861919633EC0CCB27F20D63D9B(L_0, L_1, NULL);
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:52>
		return;
	}
}
// Method Definition Index: 74356
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetize_SetGDPRMessageVersion_m00ECCFC55BE440F82D3A19E21D9217087FB269A9 (String_t* ___0_gdprMessageVersion, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:56>
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:57>
		String_t* L_0 = ___0_gdprMessageVersion;
		il2cpp_codegen_runtime_class_init_inline(LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var);
		LiftoffMonetize_SetGDPRMessageVersion_m07F8F8B135893F7CB5E5A30757322AFA28A0F5D0(L_0, NULL);
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:58>
		return;
	}
}
// Method Definition Index: 74357
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetize_SetCCPAStatus_m886F691D4D0A4E7970CC585B0B39444F0A465099 (bool ___0_ccpaStatus, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:62>
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:63>
		bool L_0 = ___0_ccpaStatus;
		il2cpp_codegen_runtime_class_init_inline(LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var);
		LiftoffMonetize_SetCCPAStatus_m169F04B7539538674F30E8B34B6658267506F302(L_0, NULL);
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:64>
		return;
	}
}
// Method Definition Index: 74358
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetize__ctor_mBBBE3B27966DCFBB3B33CA30660E7E93FEBE2992 (LiftoffMonetize_tE8B0F3247AD509D93568669B96C4AC1A5065285E* __this, const RuntimeMethod* method) 
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
// Method Definition Index: 74359
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetizeInterstitialMediationExtras__ctor_m03AF6678DF8BCC3A4ED6A46CB7EFF1C397525916 (LiftoffMonetizeInterstitialMediationExtras_tF1D3D2AF3B66A654903706934AC4C791AFA95E28* __this, const RuntimeMethod* method) 
{
	{
		LiftoffMonetizeInterstitialMediationExtras__ctor_m205AF65B48FB9B719A466D6FC33A967C6342ECC4(__this, NULL);
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
// Method Definition Index: 74360
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetizeMediationExtras__ctor_m932CD571D4F4507F7D0F4147AE6A05956A714583 (LiftoffMonetizeMediationExtras_tF6365E3164E85196EB6F5A5F50CEFFC3288C454F* __this, const RuntimeMethod* method) 
{
	{
		LiftoffMonetizeMediationExtras__ctor_m42B2D834AD632125DE97F8ADEF58D411E2E4CFA8(__this, NULL);
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
// Method Definition Index: 74361
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetizeRewardedVideoMediationExtras__ctor_m79D70C083A58DFB22D140E5E556CB9B0E75ED250 (LiftoffMonetizeRewardedVideoMediationExtras_t6085DD51055F91CE733F11A69F60C506D8CC982D* __this, const RuntimeMethod* method) 
{
	{
		LiftoffMonetizeRewardedVideoMediationExtras__ctor_m1FAE6FB4B09FF21504C732BF7799F1FDB0FB6BC4(__this, NULL);
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
// Method Definition Index: 74362
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetize_SetGDPRStatus_m80775529622818861919633EC0CCB27F20D63D9B (bool ___0_gdprStatus, String_t* ___1_consentMessageVersion, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ILiftoffMonetizeClient_t8B2099DE4AB5A1E762A85E009E1024054A35F10B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:26>
		il2cpp_codegen_runtime_class_init_inline(LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_StaticFields*)il2cpp_codegen_static_fields_for(LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var))->___client;
		bool L_1 = ___0_gdprStatus;
		String_t* L_2 = ___1_consentMessageVersion;
		NullCheck(L_0);
		InterfaceActionInvoker2< bool, String_t* >::Invoke(0, ILiftoffMonetizeClient_t8B2099DE4AB5A1E762A85E009E1024054A35F10B_il2cpp_TypeInfo_var, L_0, L_1, L_2);
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:27>
		return;
	}
}
// Method Definition Index: 74363
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetize_SetGDPRMessageVersion_m07F8F8B135893F7CB5E5A30757322AFA28A0F5D0 (String_t* ___0_gdprMessageVersion, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ILiftoffMonetizeClient_t8B2099DE4AB5A1E762A85E009E1024054A35F10B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:31>
		il2cpp_codegen_runtime_class_init_inline(LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_StaticFields*)il2cpp_codegen_static_fields_for(LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var))->___client;
		String_t* L_1 = ___0_gdprMessageVersion;
		NullCheck(L_0);
		InterfaceActionInvoker1< String_t* >::Invoke(1, ILiftoffMonetizeClient_t8B2099DE4AB5A1E762A85E009E1024054A35F10B_il2cpp_TypeInfo_var, L_0, L_1);
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:32>
		return;
	}
}
// Method Definition Index: 74364
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetize_SetCCPAStatus_m169F04B7539538674F30E8B34B6658267506F302 (bool ___0_ccpaStatus, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ILiftoffMonetizeClient_t8B2099DE4AB5A1E762A85E009E1024054A35F10B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:36>
		il2cpp_codegen_runtime_class_init_inline(LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_StaticFields*)il2cpp_codegen_static_fields_for(LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var))->___client;
		bool L_1 = ___0_ccpaStatus;
		NullCheck(L_0);
		InterfaceActionInvoker1< bool >::Invoke(2, ILiftoffMonetizeClient_t8B2099DE4AB5A1E762A85E009E1024054A35F10B_il2cpp_TypeInfo_var, L_0, L_1);
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:37>
		return;
	}
}
// Method Definition Index: 74365
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetize__ctor_m9DBEDA68E1D4E81E226A6B245BBBED714061AAF3 (LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
// Method Definition Index: 74366
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetize__cctor_m7FD02533958AC598E2052277FFF1C93EFDC71EA8 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:21>
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetize.cs:22>
		RuntimeObject* L_0;
		L_0 = LiftoffMonetizeClientFactory_CreateLiftoffMonetizeClient_m9605F7CF8B6D6E53D4DF1627397E0B2CCCCF8E96(NULL);
		((LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_StaticFields*)il2cpp_codegen_static_fields_for(LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var))->___client = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_StaticFields*)il2cpp_codegen_static_fields_for(LiftoffMonetize_tA83FC9361007ABE7FB5D5C237AF419747FF9CAD5_il2cpp_TypeInfo_var))->___client), (void*)L_0);
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
// Method Definition Index: 74367
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetizeInterstitialMediationExtras__ctor_m205AF65B48FB9B719A466D6FC33A967C6342ECC4 (LiftoffMonetizeInterstitialMediationExtras_t9ABCFD32DEB64D9CA1238EE969D02A3D876FA0FA* __this, const RuntimeMethod* method) 
{
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetizeInterstitialMediationExtras.cs:19>
		LiftoffMonetizeMediationExtras__ctor_m42B2D834AD632125DE97F8ADEF58D411E2E4CFA8(__this, NULL);
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetizeInterstitialMediationExtras.cs:19>
		return;
	}
}
// Method Definition Index: 74368
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* LiftoffMonetizeInterstitialMediationExtras_get_AndroidMediationExtraBuilderClassName_mA1E26AEDE8CCA13D88630FA36C86515AA5F52883 (LiftoffMonetizeInterstitialMediationExtras_t9ABCFD32DEB64D9CA1238EE969D02A3D876FA0FA* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral9AD9278DAE04CE0651B8FC80CE2517B992EEFF36);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetizeInterstitialMediationExtras.cs:25>
		return _stringLiteral9AD9278DAE04CE0651B8FC80CE2517B992EEFF36;
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
// Method Definition Index: 74369
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetizeMediationExtras__ctor_m42B2D834AD632125DE97F8ADEF58D411E2E4CFA8 (LiftoffMonetizeMediationExtras_tE9A01B8891754AE6A27A8D5A80C88D15683FB92F* __this, const RuntimeMethod* method) 
{
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetizeMediationExtras.cs:24>
		MediationExtras__ctor_mEFD02928F64CB007F296DC0B00BECCDC39F3869B(__this, NULL);
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetizeMediationExtras.cs:24>
		return;
	}
}
// Method Definition Index: 74370
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* LiftoffMonetizeMediationExtras_get_AndroidMediationExtraBuilderClassName_m8A62FABE3FAC3FFFD8F3B11C01430364951DB835 (LiftoffMonetizeMediationExtras_tE9A01B8891754AE6A27A8D5A80C88D15683FB92F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral18C9119C90B722EAA1F9CDB9148C197333078575);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetizeMediationExtras.cs:30>
		return _stringLiteral18C9119C90B722EAA1F9CDB9148C197333078575;
	}
}
// Method Definition Index: 74371
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* LiftoffMonetizeMediationExtras_get_IOSMediationExtraBuilderClassName_mEA46F88BE1542A6CBE42E2386DCC45C520E9FEED (LiftoffMonetizeMediationExtras_tE9A01B8891754AE6A27A8D5A80C88D15683FB92F* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralA7B2B81C30399980CEC0EBDD4721BDAE3A1A2DFD);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetizeMediationExtras.cs:36>
		return _stringLiteralA7B2B81C30399980CEC0EBDD4721BDAE3A1A2DFD;
	}
}
// Method Definition Index: 74372
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetizeMediationExtras_SetUserId_m8516B730C9229685D43DB729C201EC9FD7EC8E5C (LiftoffMonetizeMediationExtras_tE9A01B8891754AE6A27A8D5A80C88D15683FB92F* __this, String_t* ___0_userId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_Add_mC78C20D5901C87AAC38F37C906FAB6946BDE5F13_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral04CB9283C54164437AE23405A80C594A6B5EC5F3);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetizeMediationExtras.cs:41>
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_0;
		L_0 = MediationExtras_get_Extras_m301316E0049B5580869A85F9414C82445BADEB81_inline(__this, NULL);
		String_t* L_1 = ___0_userId;
		NullCheck(L_0);
		Dictionary_2_Add_mC78C20D5901C87AAC38F37C906FAB6946BDE5F13(L_0, _stringLiteral04CB9283C54164437AE23405A80C594A6B5EC5F3, L_1, Dictionary_2_Add_mC78C20D5901C87AAC38F37C906FAB6946BDE5F13_RuntimeMethod_var);
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetizeMediationExtras.cs:42>
		return;
	}
}
// Method Definition Index: 74373
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetizeMediationExtras_SetBackButtonImmediatelyEnabled_m14866A57444BAC81D8D9AF9C8B0BF1E105D4F05A (LiftoffMonetizeMediationExtras_tE9A01B8891754AE6A27A8D5A80C88D15683FB92F* __this, bool ___0_backButtonImmediatelyEnabled, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_Add_mC78C20D5901C87AAC38F37C906FAB6946BDE5F13_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral1569FBCE1AEF76BAED4D9AA69B332587D68D1AE3);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetizeMediationExtras.cs:46>
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetizeMediationExtras.cs:47>
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_0;
		L_0 = MediationExtras_get_Extras_m301316E0049B5580869A85F9414C82445BADEB81_inline(__this, NULL);
		il2cpp_codegen_runtime_class_init_inline(il2cpp_defaults.boolean_class);
		String_t* L_1;
		L_1 = Boolean_ToString_m6646C8026B1DF381A1EE8CD13549175E9703CC63((&___0_backButtonImmediatelyEnabled), NULL);
		NullCheck(L_0);
		Dictionary_2_Add_mC78C20D5901C87AAC38F37C906FAB6946BDE5F13(L_0, _stringLiteral1569FBCE1AEF76BAED4D9AA69B332587D68D1AE3, L_1, Dictionary_2_Add_mC78C20D5901C87AAC38F37C906FAB6946BDE5F13_RuntimeMethod_var);
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetizeMediationExtras.cs:48>
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
// Method Definition Index: 74374
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void LiftoffMonetizeRewardedVideoMediationExtras__ctor_m1FAE6FB4B09FF21504C732BF7799F1FDB0FB6BC4 (LiftoffMonetizeRewardedVideoMediationExtras_t14877777D71BEBE87927B9906491B401067EB1F3* __this, const RuntimeMethod* method) 
{
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetizeRewardedVideoMediationExtras.cs:19>
		LiftoffMonetizeMediationExtras__ctor_m42B2D834AD632125DE97F8ADEF58D411E2E4CFA8(__this, NULL);
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetizeRewardedVideoMediationExtras.cs:19>
		return;
	}
}
// Method Definition Index: 74375
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* LiftoffMonetizeRewardedVideoMediationExtras_get_AndroidMediationExtraBuilderClassName_m14BDB114FE96FF355E72D52A59BE76B0D2AB697F (LiftoffMonetizeRewardedVideoMediationExtras_t14877777D71BEBE87927B9906491B401067EB1F3* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral5867241742D6306548A7EB604F5B2D241B3CD423);
		s_Il2CppMethodInitialized = true;
	}
	{
		//<source_info:D:/HussWell/Assets/GoogleMobileAds/Mediation/LiftoffMonetize/Api/LiftoffMonetizeRewardedVideoMediationExtras.cs:25>
		return _stringLiteral5867241742D6306548A7EB604F5B2D241B3CD423;
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
// Method Definition Index: 74281
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* MediationExtras_get_Extras_m301316E0049B5580869A85F9414C82445BADEB81_inline (MediationExtras_t390586958F7ED4B158AD5AD18F58A86E9E7B621E* __this, const RuntimeMethod* method) 
{
	{
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_0 = __this->___U3CExtrasU3Ek__BackingField;
		return L_0;
	}
}
