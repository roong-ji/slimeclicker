using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScene : MonoBehaviour
{
    private enum SceneMode
    {
        Login,
        Register
    }

    private SceneMode _mode = SceneMode.Login;

    [Header("버튼 연결")]
    [SerializeField] private Button _gotoRegisterButton;
    [SerializeField] private Button _loginButton;
    [SerializeField] private Button _gotoLoginButton;
    [SerializeField] private Button _registerButton;
    [SerializeField] private Toggle _remeberID;

    [Header("입력 창 연결")]
    [SerializeField] private TMP_InputField _idInputField;
    [SerializeField] private TMP_InputField _passwordInputField;
    [SerializeField] private TMP_InputField _passwordConfirmInputField;
    [SerializeField] private GameObject _passwordConfirmObject;

    [Header("텍스트 연결")]
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _messageTextUI;

    private const string LastLoggedInID = "LastLoggedInID";
    private const string SecurityKey = "SecretKeyForSave";

    private void Start()
    {
        AddButtonEvents();
        Refresh();
        LoadLastLoggedInID();
    }

    private void AddButtonEvents()
    {
        _gotoRegisterButton.onClick.AddListener(GotoRegister);
        _loginButton.onClick.AddListener(Login);
        _gotoLoginButton.onClick.AddListener(GotoLogin);
        _registerButton.onClick.AddListener(Register);
    }

    private void Refresh()
    {
        _passwordConfirmObject.SetActive(_mode == SceneMode.Register);
        _gotoRegisterButton.gameObject.SetActive(_mode == SceneMode.Login);
        _loginButton.gameObject.SetActive(_mode == SceneMode.Login);
        _gotoLoginButton.gameObject.SetActive(_mode == SceneMode.Register);
        _registerButton.gameObject.SetActive(_mode == SceneMode.Register);
        _messageTextUI.text = string.Empty;
    }

    private void LoadLastLoggedInID()
    {
        if (!PlayerPrefs.HasKey(LastLoggedInID)) return;
        _idInputField.text = PlayerPrefs.GetString(LastLoggedInID);
    }

    private void Login()
    {
        var email = _idInputField.text;
        var password = _passwordInputField.text;

        if (AccountManager.Instance.TryLogin(email, password))
        {
            _messageTextUI.SetText("* 로그인 성공");
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            _messageTextUI.SetText("로그인에 실패했습니다.");
        }
    }

    private void Register()
    {
        var email = _idInputField.text;
        var password = _passwordInputField.text;
        var passwordConfirm = _passwordConfirmInputField.text;

        if (string.IsNullOrEmpty(passwordConfirm) || password != passwordConfirm)
        {
            _messageTextUI.SetText("패스워드를 확인해주세요.");
        }

        if (AccountManager.Instance.TryRegister(email, password))
        {
            _messageTextUI.SetText("* 아이디가 생성되었습니다.");
            GotoLogin();
        }
        else
        {
            _messageTextUI.SetText("회원 가입에 실패했습니다.");
        }
    }

    private void GotoLogin()
    {
        _mode = SceneMode.Login;
        _titleText.SetText("로그인");
        Refresh();
    }

    private void GotoRegister()
    {
        _mode = SceneMode.Register;
        _titleText.SetText("회원 가입");
        Refresh();
    }

    private void SetPasswordErrorMessage(string password)
    {
        if (!Reg.IsAllowedChars(password))
        {
            _messageTextUI.text = "패스워드는 영어/숫자/특수문자만 가능합니다.";
            return;
        }

        if (!Reg.IsAllowedLength(password))
        {
            _messageTextUI.text = $"패스워드는 {Reg.MinLength}자리 이상 {Reg.MaxLength}자리 이하여야 합니다.";
            return;
        }

        if (!Reg.HasSpecialChar(password))
        {
            _messageTextUI.text = "패스워드는 특수문자를 하나 이상 포함해야 합니다.";
            return;
        }

        if (!Reg.HasUpperAndLower(password))
        {
            _messageTextUI.text = "패스워드는 대소문자를 각 하나 이상 포함해야 합니다.";
            return;
        }
    }
}